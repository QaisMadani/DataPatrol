using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Worker.Services
{
    public class RequestProcessorService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public RequestProcessorService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var request = await db.UserRequests
                        .Include(r => r.User)
                        .Where(r => r.RequestDateTime <= DateTime.UtcNow
                                 && r.Status == RequestStatus.Draft)
                        .OrderBy(r => r.RequestDateTime)
                        .FirstOrDefaultAsync(stoppingToken);

                    if (request is not null)
                    {
                        request.Status = RequestStatus.InReview;
                        await db.SaveChangesAsync(stoppingToken);

                        if (request.User is null || !request.User.IsEnabled)
                            request.Status = RequestStatus.Rejected;
                        else if (request.RequestCode % 4 == 0)
                            request.Status = RequestStatus.Rejected;
                        else
                            request.Status = RequestStatus.Approved;

                        request.CompletionDateTime = DateTime.UtcNow;

                        await db.SaveChangesAsync(stoppingToken);
                    }
                }
                catch
                {
                    using var scopeErr = _scopeFactory.CreateScope();
                    var dbErr = scopeErr.ServiceProvider.GetRequiredService<AppDbContext>();

                    var errRequest = await dbErr.UserRequests
                        .Where(r => r.Status == RequestStatus.InReview)
                        .OrderByDescending(r => r.CompletionDateTime)
                        .FirstOrDefaultAsync(stoppingToken);

                    if (errRequest is not null)
                    {
                        errRequest.Status = RequestStatus.Error;
                        errRequest.CompletionDateTime = DateTime.UtcNow;
                        await dbErr.SaveChangesAsync(stoppingToken);
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}

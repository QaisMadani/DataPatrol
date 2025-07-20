using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;
        public IGenericRepository<User> Users { get; }
        public IGenericRepository<UserGroup> Groups { get; }
        public IGenericRepository<Policy> Policies { get; }
        public IGenericRepository<UserRequest> Requests { get; }

        public UnitOfWork(AppDbContext ctx)
        {
            _ctx = ctx;
            Users = new GenericRepository<User>(ctx);
            Groups = new GenericRepository<UserGroup>(ctx);
            Policies = new GenericRepository<Policy>(ctx);
            Requests = new GenericRepository<UserRequest>(ctx);
        }

        public async Task<int> CompleteAsync()
            => await _ctx.SaveChangesAsync();

        public void Dispose()
            => _ctx.Dispose();
    }
}

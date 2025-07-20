using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<UserGroup> Groups { get; }
        IGenericRepository<Policy> Policies { get; }
        IGenericRepository<UserRequest> Requests { get; }

        Task<int> CompleteAsync();
    }
}

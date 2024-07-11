using WebApi.Repositories;
using WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _context;
        public UnitOfWork(ApiContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }
        public IUserRepository Users { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

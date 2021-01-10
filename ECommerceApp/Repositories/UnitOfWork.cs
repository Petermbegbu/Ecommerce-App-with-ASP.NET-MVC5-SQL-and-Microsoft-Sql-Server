using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceApp.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
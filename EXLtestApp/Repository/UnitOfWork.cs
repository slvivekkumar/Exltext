using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXLtestApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDBContext _context;

        public UnitOfWork(AppDBContext context)
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

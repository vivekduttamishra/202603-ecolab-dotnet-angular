using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking.EFRepository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly BankingContext _context;
        private IDbContextTransaction _txn;

        public EfUnitOfWork(BankingContext context)
        {
            _context = context;
        }

        public async Task BeginAsync()
        {
            _txn = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _txn.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _txn.RollbackAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

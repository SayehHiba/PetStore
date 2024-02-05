using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;
using PetStore.Domain.Interfaces.UnitOfWork;

namespace PetStore.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Client = new ClientRepository(_context);
            Animal = new AnimalRepository(_context);
            Transactions = new TransactionsRepository(_context);
        }
        public IClientRepository Client { get; private set; }
        public IAnimalRepository Animal { get; private set; }
        public ITransactionsRepository Transactions { get; private set; }

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

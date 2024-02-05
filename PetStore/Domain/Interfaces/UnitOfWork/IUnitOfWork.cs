using Domain.Interfaces;

namespace PetStore.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimalRepository Animal { get; }
        IClientRepository Client { get; }
        ITransactionsRepository Transactions { get; }
        int Complete();
    }
}

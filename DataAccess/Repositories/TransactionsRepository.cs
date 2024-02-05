using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class TransactionsRepository : GenericRepository<Transactions>, ITransactionsRepository
    {
        public TransactionsRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

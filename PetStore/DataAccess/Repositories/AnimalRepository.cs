using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class AnimalRepository: GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApplicationContext context) : base(context)
        {

        }
    }
    
}

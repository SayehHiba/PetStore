using DataAccess.Repositories;
using DataAccess;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using PetStore.Domain.Interfaces.UnitOfWork;

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public AnimalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public void Add(Animal entity)
        {
            _unitOfWork.Animal.Add(entity);
            _unitOfWork.Complete();

        }

        [HttpPut]
        public void Update(Animal entity)
        {
            _unitOfWork.Animal.Update(entity);
            _unitOfWork.Complete();

        }

        [HttpDelete]
        public void Delete(int id)
        {
            _unitOfWork.Animal.Remove(id);
            _unitOfWork.Complete();

        }

        [HttpGet("{id}")]
        public Animal? GetById(int id)
        {
            return _unitOfWork.Animal?.GetById(id);
        }

        [HttpGet]
        public IEnumerable<Animal> GetAll()
        {
            return _unitOfWork.Animal.GetAll();
        }
    }
}

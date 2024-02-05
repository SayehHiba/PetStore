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
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpPost("add")]
        public void Add(Client entity)
        {
            _unitOfWork.Client.Add(entity);
            _unitOfWork.Complete();

        }

        [HttpPost]
        public void Update(Client entity)
        {
            _unitOfWork.Client.Update(entity);
            _unitOfWork.Complete();

        }

        [HttpDelete]
        public void Delete(int id)
        {
            _unitOfWork.Client.Remove(id);
            _unitOfWork.Complete();

        }

        [HttpGet("{id}")]
        public Client? GetById(int id)
        {
            return _unitOfWork.Client?.GetById(id);
        }

        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return _unitOfWork.Client.GetAll();
        }
    }
}

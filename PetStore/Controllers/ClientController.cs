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
        private static ILogger<ClientController> _logger;

        public ClientController(IUnitOfWork unitOfWork, ILogger<ClientController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        [HttpPost("add")]
        public void Add(Client entity)
        {
            try
            {
                _unitOfWork.Client.Add(entity);
                _unitOfWork.Complete();
                _logger.LogInformation("add client with id : {client}", entity.Client_id) ;
            }catch (Exception ex)
            {
                _logger.LogInformation("error : {e}", ex.Message);

            }
        }

        [HttpPut]
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

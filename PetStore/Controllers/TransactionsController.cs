using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using PetStore.Domain.Interfaces.UnitOfWork;
using System.Transactions;

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public void Add(Transactions entity)
        {
            _unitOfWork.Transactions.Add(entity);
            _unitOfWork.Complete();
        }

        [HttpPut]
        public void Update(Transactions entity)
        {
            _unitOfWork.Transactions.Update(entity);
            _unitOfWork.Complete();

        }

        [HttpDelete]
        public void Delete(int id)
        {
            _unitOfWork.Transactions.Remove(id);
            _unitOfWork.Complete();

        }

        [HttpGet]
        public IEnumerable<Transactions> GetAll()
        {
            return _unitOfWork.Transactions.GetAll();
        }

        [HttpGet("{id}")]
        public Transactions? GetById(int id)
        {
            return _unitOfWork.Transactions?.GetById(id);
        }

        
    }
}

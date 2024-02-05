using DataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using PetStore.DataAccess.UnitOfWork;
using PetStore.Domain.Interfaces.UnitOfWork;

namespace TestPetStore
{
    [TestFixture]
    public class ClientTest
    {

        private IUnitOfWork _unitOfWork;
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                  .UseInMemoryDatabase(databaseName: "TESTDataBase")
                  .Options;


            _unitOfWork = new UnitOfWork(new ApplicationContext(options));
        }

        [Test]
        public void GetById_ValidId_ReturnsUser()
        {
            // Arrange
            var clientId = 4;
            var expectedClient = new Client { Client_id = 4, Nom = "User 1", Prenom = "First Name 1", DateNaissance = new DateTime() };

            // Act
            var actualClient = _unitOfWork.Client.GetById(clientId);

            // Assert
            Assert.IsNotNull(actualClient);
            Assert.That(actualClient.Client_id, Is.EqualTo(expectedClient.Client_id));
            Assert.That(actualClient.Nom, Is.EqualTo(expectedClient.Nom));
            Assert.That(actualClient.Prenom, Is.EqualTo(expectedClient.Prenom));
            Assert.That(actualClient.DateNaissance, Is.EqualTo(expectedClient.DateNaissance));
        }

        [Test]
        public void Add_ValidUser_SavesToDatabase()
        {
            // Arrange
            var newClient = new Client { Client_id = 1, Nom = "Doe", Prenom = "John", DateNaissance = new DateTime() };

            // Act
            _unitOfWork.Client.Add(newClient);
            _unitOfWork.Complete();

            // Assert
            var savedClient = _unitOfWork.Client.GetById(newClient.Client_id);
            Assert.IsNotNull(savedClient);
            Assert.That(newClient.Nom, Is.EqualTo(savedClient.Nom));
            Assert.That(newClient.Prenom, Is.EqualTo(savedClient.Prenom));
            Assert.That(newClient.DateNaissance, Is.EqualTo(savedClient.DateNaissance));
        }


        [Test]
        public void Delete_ClientExists_RemovesClientFromDatabase()
        {
            // Arrange
            var clientIdToDelete = 1;

            // Act
            _unitOfWork.Client.Remove(clientIdToDelete);
            _unitOfWork.Complete();

            // Assert
            var deletedClient = _unitOfWork.Client.GetById(clientIdToDelete);
            Assert.IsNull(deletedClient); 
        }

        [Test]
        public void Update_ValidClient_UpdatesClientInDatabase()
        {
            // Arrange
            var clientIdToUpdate = 13;
            var existingClient = new Client { Client_id = 13, Nom = "Old Name", Prenom = "Old First Name", DateNaissance = new DateTime() };
            _unitOfWork.Client.Add(existingClient);
            _unitOfWork.Complete();

            var updatedClient = existingClient;
            updatedClient.Nom = "new Name";

            // Act
            _unitOfWork.Client.Update(updatedClient);
            _unitOfWork.Complete();

            // Assert
            var clientAfterUpdate = _unitOfWork.Client.GetById(clientIdToUpdate);

            Assert.IsNotNull(clientAfterUpdate);
            Assert.That(updatedClient.Nom, Is.EqualTo(clientAfterUpdate.Nom));
            Assert.That(updatedClient.Prenom, Is.EqualTo(clientAfterUpdate.Prenom));
            Assert.That(updatedClient.DateNaissance, Is.EqualTo(clientAfterUpdate.DateNaissance));
        }

        [Test]
        public void GetAll_ReturnsAllClients()
        {
            
            // Arrange
            var clients = new List<Client>
        {
            new Client { Client_id = 4, Nom = "User 1", Prenom = "First Name 1", DateNaissance = new DateTime() },
            new Client { Client_id = 5, Nom = "User 2", Prenom = "First Name 2", DateNaissance = new DateTime() },
            // Ajoutez d'autres clients si nécessaire
        };
            foreach (var client in clients)
            {
                _unitOfWork.Client.Add(client);
            }

            _unitOfWork.Complete();

         

            // Act
            var allClients = _unitOfWork.Client.GetAll();

            foreach (var client in allClients)
            {
                Console.WriteLine(client.Client_id);
            }
            // Assert
            Assert.That(clients.Count, Is.EqualTo(allClients.Count()));

        }
    }
}


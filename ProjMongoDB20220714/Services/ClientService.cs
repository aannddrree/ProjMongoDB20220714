using MongoDB.Driver;
using ProjMongoDB20220714.Models;
using ProjMongoDB20220714.Utils;
using System.Collections.Generic;

namespace ProjMongoDB20220714.Services
{
    public class ClientService
    {

        private readonly IMongoCollection<Client> _clients;

        public ClientService(IProjMongoDotnetDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Client>(settings.ClientCollectionName);
        }

        public List<Client> Get() =>
            _clients.Find(cliente => true).ToList();

        public Client Get(string id) =>
            _clients.Find<Client>(cliente => cliente.Id == id).FirstOrDefault();

        public Client Create(Client cliente)
        {
            _clients.InsertOne(cliente);
            return cliente;
        }

        public void Update(string id, Client clienteIn) =>
            _clients.ReplaceOne(cliente => cliente.Id == id, clienteIn);

        public void Remove(Client clienteIn) =>
            _clients.DeleteOne(cliente => cliente.Id == clienteIn.Id);

        public void Remove(string id) =>
            _clients.DeleteOne(cliente => cliente.Id == id);
    }
}

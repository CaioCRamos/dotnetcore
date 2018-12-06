using System;
using System.Collections.Generic;

namespace FirstWebApi.Entities
{
    public class Clients : IClients
    {
        public Client Get(Guid id) =>
            Client.Load(Guid.NewGuid(), "Caio", "Ramos");

        public List<Client> GetAll() =>
            new List<Client> 
            {
                Client.Load(Guid.NewGuid(), "Caio", "Ramos"),
                Client.Load(Guid.NewGuid(), "Carla", "Ramos"),
                Client.Load(Guid.NewGuid(), "Tatiane", "Amaral")                
            };

        public bool Save(Client client) => true;            
    }
}
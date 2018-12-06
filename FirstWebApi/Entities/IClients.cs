using System;
using System.Collections.Generic;

namespace FirstWebApi.Entities
{
    public interface IClients
    {
        Client Get(Guid id);

        List<Client> GetAll();

        bool Save(Client client);
    }
}
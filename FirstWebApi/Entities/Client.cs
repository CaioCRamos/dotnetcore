using System;

namespace FirstWebApi.Entities
{
    public class Client
    {
        public static Client New (string name, string lastName) =>
            new Client 
            {
                Id = Guid.NewGuid(),
                Name = name,
                LastName = lastName
            };

        public static Client Load (Guid id, string name, string lastName) => 
            new Client
            {
                Id = id,
                Name = name,
                LastName = lastName
            };

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string LastName { get; private set;}
    }
}
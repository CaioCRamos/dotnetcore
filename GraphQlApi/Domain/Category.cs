using System;

namespace GraphQlApi.Domain
{
    public class Category
    {
        public static Category Load (Guid id, string name)
            => new Category
            {
                Id = id,
                Name = name
            };

        private Category() {}

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}
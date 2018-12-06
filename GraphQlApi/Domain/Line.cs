using System;

namespace GraphQlApi.Domain
{
    public class Line 
    {    
        public static Line Load(Guid id, string name)
            => new Line 
            {
                Id = id,
                Name = name
            };

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
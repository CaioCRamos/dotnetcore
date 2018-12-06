using System;
using System.Collections.Generic;

namespace GraphQlApi.Domain
{
    public class Product
    {
        public static Product New(string name, Line line)
            => new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Line = line,
                _presentations = new List<Presentation>()
            };

        public static Product Load(Guid id, string name, Line line, List<Presentation> presentations)
            => new Product
            {
                Id = id,
                Name = name,
                Line = line,
                _presentations = presentations
            };

        private Product() {}

        private List<Presentation> _presentations;

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Line Line { get; private set; }

        public string ImageUrl => string.Format("https://localhost:5001/api/products/{0}/image", Id.ToString());

        public string BundleUrl => string.Format("https://localhost:5001/api/products/{0}/bundle", Id.ToString());

        public IReadOnlyCollection<Presentation> Presentations => _presentations;
    }
}
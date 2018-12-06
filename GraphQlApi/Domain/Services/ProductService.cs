using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQlApi.Domain.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetAll()
            => GetInMemoryProductList();

        public Product GetById(Guid id)
            => GetInMemoryProductList().First();

        private List<Product> GetInMemoryProductList()
        {
            var slides = new List<Slide>
            {
                Slide.Load(Guid.NewGuid(), 1),
                Slide.Load(Guid.NewGuid(), 2),
                Slide.Load(Guid.NewGuid(), 3)
            };

            var visualAid = Category.Load(Guid.NewGuid(), "Visual Aid");
            var file = Category.Load(Guid.NewGuid(), "File");

            var mainPresentation = Presentation.Load(Guid.NewGuid(), "Main Presentation", visualAid, DateTime.Now, slides);
            var complementaryPresentation = Presentation.Load(Guid.NewGuid(), "Complementary Presentation", file, DateTime.Now, slides.Take(2).ToList());

            var line = Line.Load(Guid.NewGuid(), "First Line");

            return new List<Product>
            {
                Product.Load(Guid.NewGuid(), "First Product", line, new List<Presentation> { mainPresentation, complementaryPresentation }),
                Product.Load(Guid.NewGuid(), "Second Product", line, new List<Presentation> { mainPresentation }),
                Product.Load(Guid.NewGuid(), "Trird Product", line, new List<Presentation> { complementaryPresentation })
            };
        }
    }
}
using System;
using System.Collections.Generic;

namespace GraphQlApi.Domain.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product GetById(Guid id);
    }
}
using System;
using GraphQL.Types;
using GraphQlApi.Domain;
using GraphQlApi.Domain.Services;
using GraphQlApi.GraphQL.Types;

namespace GraphQlApi.GraphQL.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>(
                name: "products",
                resolve: context =>
                {
                    return productService.GetAll();
                });

            Field<ProductType>(
                name: "product",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "Product's ID" }
                ),
                resolve: context => 
                {
                    var id = context.GetArgument<Guid>("id");
                    return productService.GetById(id);
                });
        }
    }
}
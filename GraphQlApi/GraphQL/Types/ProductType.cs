using System;
using GraphQL.Types;
using GraphQlApi.Domain;

namespace GraphQlApi.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";

            Field(p => p.Id, type: typeof(IdGraphType)).Description("Product's ID");
            Field(p => p.Name).Description("Product's name");
            Field(p => p.Line, type: typeof(LineType)).Description("Product's line");
            Field(p => p.ImageUrl).Description("Product's image url");
            Field(p => p.BundleUrl).Description("Product's bundle url");
            Field(p => p.Presentations, type: typeof(ListGraphType<PresentationType>)).Description("Product's presentations");            
        }
    }
}
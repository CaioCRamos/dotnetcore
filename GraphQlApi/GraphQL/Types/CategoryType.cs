using GraphQL.Types;
using GraphQlApi.Domain;

namespace GraphQlApi.GraphQL.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Name = "Category";

            Field(t => t.Id, type: typeof(IdGraphType)).Description("Category's ID");
            Field(t => t.Name).Description("Category's name");
        }
    }
}
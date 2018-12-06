using GraphQL.Types;
using GraphQlApi.Domain;

namespace GraphQlApi.GraphQL.Types
{
    public class SlideType : ObjectGraphType<Slide>
    {
        public SlideType()
        {
            Name = "Slide";

            Field(s => s.Id, type: typeof(IdGraphType)).Description("Slide's ID");
            Field(s => s.Order).Description("Slide's order");
        }
    }
}
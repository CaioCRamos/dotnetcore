using GraphQL.Types;
using GraphQlApi.Domain;

namespace GraphQlApi.GraphQL.Types
{
    public class LineType : ObjectGraphType<Line>
    {
        public LineType()
        {
            Name = "Line";

            Field(t => t.Id, type: typeof(IdGraphType)).Description("Line's ID");
            Field(t => t.Name).Description("Line's name");
        }
    }
}
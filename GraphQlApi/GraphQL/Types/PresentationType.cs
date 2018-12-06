using GraphQL.Types;
using GraphQlApi.Domain;

namespace GraphQlApi.GraphQL.Types
{
    public class PresentationType : ObjectGraphType<Presentation>
    {
        public PresentationType()
        {
            Name = "Presentation";

            Field(p => p.Id, type: typeof(IdGraphType)).Description("Presentation's ID");
            Field(p => p.Name).Description("Presentation'n name");
            Field(p => p.Category, type: typeof(CategoryType)).Description("Presentation's category");
            Field(p => p.ReleaseDate).Description("Presentation's release date");
            Field(p => p.Slides, type: typeof(ListGraphType<SlideType>)).Description("Presentation's slides");
        }
    }
}
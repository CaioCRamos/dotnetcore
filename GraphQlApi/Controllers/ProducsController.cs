using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQlApi.Domain.Services;
using GraphQlApi.GraphQL;
using GraphQlApi.GraphQL.Queries;
using Microsoft.AspNetCore.Mvc;
using GraphQL.Validation.Complexity;
using GraphQL.Instrumentation;

namespace GraphQlApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLRequest request)
        {
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = new Schema() { Query = new ProductQuery(_productService) };
                _.Query = request.Query;
            }).ConfigureAwait(false);

            if(result.Errors?.Count > 0)
                return BadRequest(new { Errors = result.Errors });
            
            return Ok(result);
        }
    }
}
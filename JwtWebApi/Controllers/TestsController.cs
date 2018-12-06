using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class TestsController : ControllerBase
    {
        [HttpGet]        
        public ActionResult<IEnumerable<string>> Get()
        {
            return new List<string>
            {
                "Luke", 
                "Leia", 
                "Sadan", 
                "Amarelo"
            };
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CmdApi.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> index()
        {
            return new string[] {
                "api/commands",
                "api/commands/{id}"
            };
        }
    }
}
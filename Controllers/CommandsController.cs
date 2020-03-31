using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CmdApi.Models;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController (CommandContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> getCommands()
        {
            return _context.CommandItems;
        }
    }
}
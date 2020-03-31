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
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _context.CommandItems;
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _context.CommandItems.Find(id);
            
            if (command == null) {
                return NotFound();
            }

            return command;
        }

        [HttpPost]
        public ActionResult<Command> PostCommand(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCommandById), new Command{Id = command.Id}, command);
        }

        [HttpPut("{id}")]
        public ActionResult<Command> PutCommand(int id, Command newCommand)
        {
            var command = _context.CommandItems.Find(id);

            if (command == null) {
                return NotFound();
            }

            command.HowTo = newCommand.HowTo;
            command.Platform = newCommand.Platform;
            command.CommandLine = newCommand.CommandLine;

            _context.CommandItems.Update(command);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCommandById), new Command{Id = command.Id}, command);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCommand(int id)
        {
            var command = _context.CommandItems.Find(id);

            if (command == null) {
                return NotFound();
            }

            _context.CommandItems.Remove(command);
            _context.SaveChanges();

            return Ok();
        }
    }
}
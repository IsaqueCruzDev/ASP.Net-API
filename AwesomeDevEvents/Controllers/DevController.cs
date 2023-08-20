using AwesomeDevEvents.Models;
using AwesomeDevEvents.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace AwesomeDevEvents.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevController : Controller
    {

        private readonly DevEventsDBContext _context;

        public DevController(DevEventsDBContext context)
        {
            _context = context;
        }

        // api/dev-events GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvent = _context.DevEvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvent);
        }

        // api/dev-events/123456 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvent);
        }
        // api/dev-events/123456 POST
        [HttpPost]
        public IActionResult Post(DevEventModels devEvent)
        {
            _context.DevEvents.Add(devEvent);

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }
        // api/dev-events/123456 UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEventModels input)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }
        // api/dev-events/213456 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();
            return NoContent();
        }

    }
}

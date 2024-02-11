using Microsoft.AspNetCore.Mvc;
using PropertiesAPI.Models;
using PropertiesAPI.Services;

namespace PropertiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service; 

        public PropertiesController(IPropertyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            var properties = _service.GetProperties();

            if (properties.Count() > 0) return Ok(properties.Skip(skip).Take(take));

            return Ok(new List<Property>());
        }

        [HttpGet("{id}")]
        public IActionResult GetPropertyById(int id)
        {
            var property = _service.GetById(id);

            if(property != null)
            {
                return Ok(property);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Property property)
        {
            _service.Register(property);
            return CreatedAtAction(nameof(GetPropertyById), new { id = property.Id }, property);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Property updatedProperty)
        {
            var originalProperty = _service.GetById(id);

            if (originalProperty == null) return NotFound();

            _service.Update(originalProperty, updatedProperty);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Update(int id)
        {
            var property = _service.GetById(id);

            if (property == null) return NotFound();

            _service.Delete(property);

            return NoContent();
        }

    }
}

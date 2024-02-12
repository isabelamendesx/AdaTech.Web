using AutoMapper;
using DeliveryGuyAPI.Configurations.Filters;
using DeliveryGuyAPI.Data.Dtos;
using DeliveryGuyAPI.Models;
using DeliveryGuyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryGuyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryGuyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DeliveryGuy> _repository;

        public DeliveryGuyController(IMapper mapper, IRepository<DeliveryGuy> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll().Select(dg => _mapper.Map<ReadDeliveryGuyDto>(dg)));
        }

        [HttpGet("/{id}")]
        public IActionResult GetById(int id)
        {
            var deliveryGuy = _repository.GetById(id);

            if (deliveryGuy != null)
            {
                return Ok(_mapper.Map<ReadDeliveryGuyDto>(deliveryGuy));
            }

            return NotFound();
        }

        [HttpGet("CPF/{CPF}")]
        public IActionResult GetByCpf(string CPF)
        {
            var deliveryGuy = _repository.GetAll().FirstOrDefault(dg => dg.CPF.Equals(CPF));

            if (deliveryGuy != null)
            {
                return Ok(_mapper.Map<ReadDeliveryGuyDto>(deliveryGuy));
            }

            return NotFound();
        }

        [HttpPost]
        [MyAuthorizationActionFilter]
        public IActionResult Post([FromBody] CreateDeliveryGuyDto deliveryGuyDto) 
        {
            var deliveryGuy = _mapper.Map<DeliveryGuy>(deliveryGuyDto);
            _repository.Add(deliveryGuy);
            return CreatedAtAction(nameof(GetById), new { id = deliveryGuy.Id}, deliveryGuy);
        }


    }
}

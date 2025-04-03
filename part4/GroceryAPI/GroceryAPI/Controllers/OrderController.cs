using AutoMapper;
using Grocery.Core.Models;
using Grocery.Core.Service;
using GroceryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderPostModel order)
        {
            try
            {
                _orderService.AddOrder(_mapper.Map<Order>(order));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult OrderConfirmation(int id)
        {
            _orderService.OrderConfirmation(id);
            return Ok();
        }
        // PUT api/<OrderController>/5
        [HttpPut("{id}/complet")]
        public IActionResult OrderCompleted(int id)
        {
            _orderService.OrderCompleted(id);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Data;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ApplicationDbContext _context;

        public OrderController(ILogger<OrderController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            
            return Ok(order);
        }

        [HttpGet("{orderId:int}")]
        public IActionResult GetOrderById(int orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            
            return (order != null) ? Ok(order) : NotFound();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParcelDeliveryService.Models;

namespace ParcelDeliveryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly ParcelDeliveryService _parcelDeliveryService;

        public DeliveryController(ParcelDeliveryService parcelDeliveryService)
        {
            _parcelDeliveryService = parcelDeliveryService;
        }

        [HttpPost("create")]
        public IActionResult CreateDelivery(Delivery delivery)
        {
            var newDelivery = _parcelDeliveryService.CreateDelivery(delivery);
            
            return Ok(newDelivery);
        }

        [HttpGet("{deliveryId}")]
        public IActionResult GetDelivery(int deliveryId)
        {
            var delivery = _parcelDeliveryService.GetDeliveryById(deliveryId);
            
            return (delivery != null) ? Ok(delivery) : NotFound();
        }
    }
}
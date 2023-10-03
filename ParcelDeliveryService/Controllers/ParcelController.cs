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
    public class ParcelController : ControllerBase
    {
        private readonly ParcelDeliveryService _parcelDeliveryService;

        public ParcelController(ParcelDeliveryService parcelDeliveryService)
        {
            _parcelDeliveryService = parcelDeliveryService;
        }

        [HttpPost("create")]
        public IActionResult CreateParcel(Parcel parcel)
        {
            var newParcel = _parcelDeliveryService.CreateParcel(parcel);
            
            return Ok(newParcel);
        }

        [HttpGet("{parcelId}")]
        public IActionResult GetParcel(int parcelId)
        {
            var parcel = _parcelDeliveryService.GetParcelById(parcelId);
            
            return (parcel != null) ? Ok(parcel) : NotFound();
        }
    }
}
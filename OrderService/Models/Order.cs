using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public DateTime ShipDate { get; set; }

        public OrderStatus Status { get; set; }

        public bool Complete { get; set; } = false;
    }
}
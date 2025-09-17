using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string CustomerId { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
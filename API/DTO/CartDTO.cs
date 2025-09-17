using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public string? CustomerId { get; set; } = null!;
        public List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();
    }
}
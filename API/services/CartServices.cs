using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using API.interfaces;

namespace API.services
{
    public class CartServices : ICartServices
    {
        private readonly DataContext _db;

        public CartServices(DataContext db)
        {
            _db = db;
        }

        public void AddItem(Cart cart, Product product, int quantity)
        {
            var item = _db.CartItems.FirstOrDefault(c => c.CartId == cart.CartId && c.ProductId == product.Id);

            if (item == null)
            {
                _db.CartItems.Add(new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = product.Id,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void DeleteItem(Cart cart, int productId, int quantity)
        {
            var item = _db.CartItems.Where(c => c.CartId == cart.CartId && c.ProductId == productId).FirstOrDefault();

            if (item == null) return;
            else item.Quantity -= quantity;

            if (item.Quantity <= 0)
            {
                _db.CartItems.Remove(item);
            }
        }
    }
}
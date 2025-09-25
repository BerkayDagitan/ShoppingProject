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

        public void AddItem(Product product, int quantity)
        {
            var item = _db.CartItems.Where(c => c.ProductId == product.Id).FirstOrDefault();

            if (item == null)
            {
                _db.CartItems.Add(new CartItem { Product = product, Quantity = quantity, ProductId = product.Id });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void DeleteItem(int productId, int quantity)
        {
            var item = _db.CartItems.Where(c => c.ProductId == productId).FirstOrDefault();

            if (item == null) return;
            else item.Quantity -= quantity;

            if (item.Quantity == 0)
            {
                _db.CartItems.Remove(item);
            }
        }
    }
}
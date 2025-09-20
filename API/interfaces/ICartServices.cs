using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entity;

namespace API.interfaces
{
    public interface ICartServices
    {
        public void AddItem(Cart cart, Product product, int quantity);
        public void DeleteItem(int productId, int quantity);
    }
}
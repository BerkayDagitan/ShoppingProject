using API.Data;
using API.DTO;
using API.Entity;
using API.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cart;
        private readonly DataContext _db;

        public CartController(DataContext db, ICartServices cart)
        {
            _db = db;
            _cart = cart;
        }

        [HttpGet]
        public async Task<ActionResult<CartDTO>> GetCart()
        {
            return CartToDTO(await GetOrCreate());
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(int productId, int quantity)
        {
            var cart = await GetOrCreate();
            var product = await _db.Products.FirstOrDefaultAsync(i => i.Id == productId);

            if (product == null) return NotFound("Product not found");

            _cart.AddItem(product, quantity);
            var result = await _db.SaveChangesAsync() > 0;

            if (result) return CreatedAtAction(nameof(GetCart), CartToDTO(cart));

            return BadRequest(new ProblemDetails { Title = "Problem adding item to cart" });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItemFromCart(int productId, int quantity)
        {
            var cart = GetOrCreate();

            _cart.DeleteItem(productId, quantity);

            var result = await _db.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem removing item from the cart" });
        }

        private async Task<Cart> GetOrCreate()
        {
            var cart = await _db.Carts.Include(i => i.CartItems).ThenInclude(i => i.Product).Where(i => i.CustomerId == Request.Cookies["customerId"]).FirstOrDefaultAsync();

            if (cart == null)
            {
                var customerId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.Now.AddDays(30)
                };
                Response.Cookies.Append("customerId", customerId, cookieOptions);
                cart = new Cart { CustomerId = customerId };

                _db.Carts.Add(cart);
                await _db.SaveChangesAsync();
            }
            return cart;
        }

        private CartDTO CartToDTO(Cart cart)
        {
            return new CartDTO
            {
                CartId = cart.CartId,
                CustomerId = cart.CustomerId,
                CartItems = cart.CartItems.Select(Item => new CartItemDTO
                {
                    ProductId = Item.ProductId,
                    Name = Item.Product.Name,
                    Price = Item.Product.Price,
                    Quantity = Item.Quantity,
                    ImageUrl = Item.Product.ImageUrl
                }).ToList()
            };
        }
    }
}
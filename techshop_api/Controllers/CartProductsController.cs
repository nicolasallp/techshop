using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using techshop_api.Data;
using techshop_api.Dtos;
using techshop_api.Models;

namespace techshop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartProduct>>> GetCarts()
        {
            return await _context.CartProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartProduct>> GetCartProduct(string id)
        {
            var cartProduct = await _context.CartProducts.FindAsync(id);

            if (cartProduct == null)
            {
                return NotFound();
            }

            return cartProduct;
        }

        [HttpGet("ByUser/{id}")]
        public async Task<ActionResult<IEnumerable<CartProduct>>> GetCartsByUser(string id)
        {
            return await _context.CartProducts
                .Include(c => c.User)
                .Include(c => c.Product)
                .Where(c => c.UserId == id).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartProduct(string id, CartProductUpdateDto cartProductDto)
        {
            CartProduct cartProduct = new()
            {
                Id = id,
                UserId = cartProductDto.UserId,
                ProductId = cartProductDto.ProductId,
                Quantity = cartProductDto.Quantity
            };

            if (id != cartProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CartProduct>> PostCartProduct(CartProductCreateDto cartProductDto)
        {
            CartProduct cart = new CartProduct
            {
                Id = Guid.NewGuid().ToString(),
                UserId = cartProductDto.UserId,
                ProductId = cartProductDto.ProductId,
                Quantity = cartProductDto.Quantity
            };
            _context.CartProducts.Add(cart);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartProductExists(cart.Id!))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetCartProduct), new { id = cart.Id }, cart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartProduct(string id)
        {
            var cartProduct = await _context.CartProducts.FindAsync(id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartProductExists(string id)
        {
            return _context.CartProducts.Any(e => e.Id == id);
        }
    }
}

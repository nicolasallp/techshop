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
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(string id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        public async Task<ActionResult<Product>> PostProduct(ProductCreateDto productDto)
        {
            //string base64Data = productDto.Image!.Split(",")[0];
            //string fileName = productDto.Image.Split(",")[1];
            //string contentType = productDto.Image.Split(",")[2];

            //byte[] fileBytes = Convert.FromBase64String(base64Data);
            //using MemoryStream memoryStream = new MemoryStream(fileBytes);
            //IFormFile file = new FormFile(memoryStream, 0, fileBytes.Length, "file", fileName)
            //{
            //    Headers = new HeaderDictionary(),
            //    ContentType = contentType
            //};

            //string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            //using FileStream stream = new FileStream(Path.Combine(path, imageName), FileMode.Create);
            //await file.CopyToAsync(stream);

            Product product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Brand = productDto.Brand,
                Availability = productDto.Availability,
                Image = productDto.Image
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVendaFacil.Models;
using ApiVendaFacil.Data;

namespace ApiVendaFacil.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Product>> Get(
            [FromServices] DataContext ctx)
        {
            return await ctx.Products
                .Include(product => product.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<Product> Fetch(
            [FromServices] DataContext ctx,
            long id)
        {
            return await ctx.Products.AsNoTracking()
                .FirstOrDefaultAsync(product => product.Id == id);
        }

        [HttpPost]
        public async Task<Product> Create(
            [FromServices] DataContext ctx,
            [FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                ctx.Products.Add(product);
                await ctx.SaveChangesAsync();
                return product;
            }

            return null;
        }

        [HttpPut("{id:long}")]
        public async Task<Product> Update(
            [FromServices] DataContext ctx,
            long id,
            [FromBody] Product product)
        {
            if (this.Fetch(ctx, id) != null)
            {
                if (ModelState.IsValid)
                {
                    ctx.Products.Update(product);
                    await ctx.SaveChangesAsync();
                    return product;
                }
            }

            return null;
        }

        [HttpDelete("{id:long}")]
        public async Task<bool> Delete(
            [FromServices] DataContext ctx,
            long id)
        {
            var product = await ctx.Products.AsNoTracking()
                .FirstOrDefaultAsync(product => product.Id == id);
            
            if (product != null)
            {
                ctx.Products.Remove(product);
                await ctx.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

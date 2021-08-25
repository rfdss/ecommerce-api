using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVendaFacil.Models;
using ApiVendaFacil.Data;

namespace ApiVendaFacil.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Category>> Get(
            [FromServices] DataContext ctx)
        {
            return await ctx.Categories
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<Category> Fetch(
            [FromServices] DataContext ctx,
            long id)
        {
            return await ctx.Categories.AsNoTracking()
                .FirstOrDefaultAsync(category => category.Id == id);
        }

        [HttpPost]
        public async Task<Category> Create(
            [FromServices] DataContext ctx,
            [FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                ctx.Categories.Add(category);
                await ctx.SaveChangesAsync();
                return category;
            }

            return null;
        }

        [HttpPut("{id:long}")]
        public async Task<Category> Update(
            [FromServices] DataContext ctx,
            long id,
            [FromBody] Category category)
        {
            if (this.Fetch(ctx, id) != null)
            {
                if (ModelState.IsValid)
                {
                    ctx.Categories.Update(category);
                    await ctx.SaveChangesAsync();
                    return category;
                }
            }

            return null;
        }

        [HttpDelete("{id:long}")]
        public async Task<bool> Delete(
            [FromServices] DataContext ctx,
            long id)
        {
            var category = await ctx.Categories.AsNoTracking()
                .FirstOrDefaultAsync(category => category.Id == id);
            
            if (category != null)
            {
                ctx.Categories.Remove(category);
                await ctx.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

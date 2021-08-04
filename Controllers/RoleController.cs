using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVendaFacil.Models;
using ApiVendaFacil.Data;

namespace ApiVendaFacil.Controllers
{
    [ApiController]
    [Route("v1/roles")]
    public class RoleController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Role>> Get(
            [FromServices] DataContext ctx)
        {
            return await ctx.Roles
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<Role> Fetch(
            [FromServices] DataContext ctx,
            long id)
        {
            return await ctx.Roles.AsNoTracking()
                .FirstOrDefaultAsync(role => role.Id == id);
        }

        [HttpPost]
        public async Task<Role> Create(
            [FromServices] DataContext ctx,
            [FromBody] Role role)
        {
            if (ModelState.IsValid)
            {
                ctx.Roles.Add(role);
                await ctx.SaveChangesAsync();
                return role;
            }

            return null;
        }

        [HttpPut("{id:long}")]
        public async Task<Role> Update(
            [FromServices] DataContext ctx,
            long id,
            [FromBody] Role role)
        {
            if (this.Fetch(ctx, id) != null)
            {
                if (ModelState.IsValid)
                {
                    ctx.Roles.Update(role);
                    await ctx.SaveChangesAsync();
                    return role;
                }
            }

            return null;
        }

        [HttpDelete("{id:long}")]
        public async Task<bool> Delete(
            [FromServices] DataContext ctx,
            long id)
        {
            var role = await ctx.Roles.AsNoTracking()
                .FirstOrDefaultAsync(role => role.Id == id);
            
            if (role != null)
            {
                ctx.Roles.Remove(role);
                await ctx.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

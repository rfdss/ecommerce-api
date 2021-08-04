using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ApiVendaFacil.Models;
using ApiVendaFacil.Data;

namespace ApiVendaFacil.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<User>> Get(
            [FromServices] DataContext ctx)
        {
            return await ctx.Users
                .Include(user => user.Role)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<User> Fetch(
            [FromServices] DataContext ctx,
            long id)
        {
            return await ctx.Users.AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        [HttpPost]
        public async Task<User> Create(
            [FromServices] DataContext ctx,
            [FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                /*var role = await ctx.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(role => role.Id == user.RoleId);

                if (role == null)
                {
                    throw new Exception("Role not found");
                }*/

                ctx.Users.Add(user);
                await ctx.SaveChangesAsync();
                return user;
            }

            return null;
        }

        [HttpPut("{id:long}")]
        public async Task<User> Update(
            [FromServices] DataContext ctx,
            long id,
            [FromBody] User user)
        {
            if (this.Fetch(ctx, id) != null)
            {
                if (ModelState.IsValid)
                {
                    ctx.Users.Update(user);
                    await ctx.SaveChangesAsync();
                    return user;
                }
            }

            return null;
        }

        [HttpDelete("{id:long}")]
        public async Task<bool> Delete(
            [FromServices] DataContext ctx,
            long id)
        {
            var user = await ctx.Users.AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);
            
            if (user != null)
            {
                ctx.Users.Remove(user);
                await ctx.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

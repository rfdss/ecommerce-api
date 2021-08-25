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
    [Route("v1/customers")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get(
            [FromServices] DataContext ctx)
        {
            return await ctx.Customers
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<Customer> Fetch(
            [FromServices] DataContext ctx,
            long id)
        {
            return await ctx.Customers.AsNoTracking()
                .FirstOrDefaultAsync(customer => customer.Id == id);
        }

        [HttpPost]
        public async Task<Customer> Create(
            [FromServices] DataContext ctx,
            [FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                ctx.Customers.Add(customer);
                await ctx.SaveChangesAsync();
                return customer;
            }

            return null;
        }

        [HttpPut("{id:long}")]
        public async Task<Customer> Update(
            [FromServices] DataContext ctx,
            long id,
            [FromBody] Customer customer)
        {
            if (this.Fetch(ctx, id) != null)
            {
                if (ModelState.IsValid)
                {
                    ctx.Customers.Update(customer);
                    await ctx.SaveChangesAsync();
                    return customer;
                }
            }

            return null;
        }

        [HttpDelete("{id:long}")]
        public async Task<bool> Delete(
            [FromServices] DataContext ctx,
            long id)
        {
            var customer = await ctx.Customers.AsNoTracking()
                .FirstOrDefaultAsync(customer => customer.Id == id);
            
            if (customer != null)
            {
                ctx.Customers.Remove(customer);
                await ctx.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

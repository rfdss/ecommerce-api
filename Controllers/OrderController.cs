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
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Order>> Get(
            [FromServices] DataContext ctx)
        {
            return await ctx.Orders
                .Include(order => order.User)
                .Include(order => order.Customer)
                .Include(order => order.Items)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<Order> Fetch(
            [FromServices] DataContext ctx,
            long id)
        {
            return await ctx.Orders
                .Include(order => order.User)
                .Include(order => order.Customer)
                // .Include(order => order.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(order => order.Id == id);
        }

        [HttpPost]
        public async Task<Order> Create(
            [FromServices] DataContext ctx,
            [FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                ctx.Orders.Add(order);
                await ctx.SaveChangesAsync();
                return order;
            }

            return null;
        }

        [HttpPut("{id:long}")]
        public async Task<Order> Update(
            [FromServices] DataContext ctx,
            long id,
            [FromBody] Order order)
        {
            if (this.Fetch(ctx, id) != null)
            {
                if (ModelState.IsValid)
                {
                    ctx.Orders.Update(order);
                    await ctx.SaveChangesAsync();
                    return order;
                }
            }

            return null;
        }

        [HttpGet]
        [Route("{id:long}/items")]
        public async Task<IEnumerable<OrderItem>> GetItems(
            [FromServices] DataContext ctx,
            long id)
        {
            return await ctx.OrderItems
                .Where(orderItem => orderItem.OrderId == id)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpPut]
        [Route("{id:long}/items")]
        public async Task<IEnumerable<OrderItem>> UpdateItems(
            [FromServices] DataContext ctx,
            long id,
            [FromBody] List<OrderItem> items)
        {
            if (this.Fetch(ctx, id) != null)
            {
                if (ModelState.IsValid)
                {
                    var currentItems = ctx.OrderItems.Where(item => item.OrderId == id);
                    if (currentItems.Count() > 0)
                    {
                        ctx.OrderItems.RemoveRange(currentItems);
                        await ctx.SaveChangesAsync();
                    }

                    foreach (var item in items)
                    {
                        await ctx.OrderItems.AddAsync(item);
                    }

                    await ctx.SaveChangesAsync();
                    return items;
                }
            }

            return null;
        }
    }
}

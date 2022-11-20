using AutoMapper;
using TheRocket.Dtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;
using TheRocket.Entities;
using Microsoft.EntityFrameworkCore;

namespace TheRocket.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IMapper Mapper;
        private readonly TheRocketDbContext Context;
        public OrderRepo(TheRocketDbContext context, IMapper mapper)
        {
            Context=context;
            Mapper=mapper;
        }
        public async Task<SharedResponse<OrderDto>> Create(OrderDto model)
        {
            if (Context.Orders == null)
            {
                return new SharedResponse<OrderDto>(Status.problem, null, "Entity Set 'db.Plans' is null");
            }
            Order order = new Order();
            Mapper.Map(model, order);
            Context.Orders.Add(order);
            try
            {
                await Context.SaveChangesAsync();
                model = Mapper.Map(order, model);
                return new SharedResponse<OrderDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<OrderDto>(Status.badRequest, null, ex.ToString());
            }
        }

        public async Task<SharedResponse<OrderDto>> Delete(int Id)
        {
            if (Context.Orders == null)
            {
                return new SharedResponse<OrderDto>(Status.notFound, null);

            }
            var order = await Context.Orders.Where(o => o.Id == Id && o.IsDeleted == false).FirstOrDefaultAsync();
            if (order == null)
            {
                return new SharedResponse<OrderDto>(Status.notFound, null);
            }
            order.IsDeleted = true;
            await Context.SaveChangesAsync();
            return new SharedResponse<OrderDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<OrderDto>>> GetAll()
        {
            if (Context.Orders == null)
                return new SharedResponse<List<OrderDto>>(Status.notFound, null);
            var orders = await Context.Orders.Where(o => o.IsDeleted == false).ToListAsync();
            List<OrderDto> Orders = Mapper.Map<List<OrderDto>>(orders);
            return new SharedResponse<List<OrderDto>>(Status.found, Orders);
        }

        public async Task<SharedResponse<OrderDto>> GetById(int Id)
        {
            var order = await Context.Orders.Where(o => o.Id == Id).FirstOrDefaultAsync();
            OrderDto Order = Mapper.Map<OrderDto>(order);
            return new SharedResponse<OrderDto>(Status.found, Order);
        }

        public bool IsExists(int Id)
        {
            return (Context.Orders?.Any(o => o.Id == Id && o.IsDeleted==false)).GetValueOrDefault();
        }

        public async Task<SharedResponse<OrderDto>> Update(int Id, OrderDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<OrderDto>(Status.badRequest, null);
            }

            Order order = Mapper.Map<Order>(model);

            Context.Entry(order).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await Context.SaveChangesAsync();
                else
                    return new SharedResponse<OrderDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<OrderDto>(Status.noContent, null);
        }
    }
}

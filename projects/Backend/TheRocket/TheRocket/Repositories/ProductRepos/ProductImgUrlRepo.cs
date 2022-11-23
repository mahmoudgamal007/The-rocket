using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class ProductImgUrlRepo : IProductImgUrlRepo
    {

        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;

        public ProductImgUrlRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<SharedResponse<ProductImgUrlDto>> Create(ProductImgUrlDto model)
        {


            if (db.ProductImgUrls == null)
            {
                return new SharedResponse<ProductImgUrlDto>(Status.problem, null, "Entity Set 'db.ProductImgUrl' is null");
            }
            ProductImgUrl ProductImgUrl = mapper.Map<ProductImgUrl>(model);
            db.ProductImgUrls.Add(ProductImgUrl);
            try
            {
                await db.SaveChangesAsync();
                model = mapper.Map<ProductImgUrlDto>(ProductImgUrl);
                return new SharedResponse<ProductImgUrlDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<ProductImgUrlDto>(Status.badRequest, null, ex.ToString());
            }

        }

        public async Task<SharedResponse<ProductImgUrlDto>> Delete(int Id)
        {
            if (db.ProductImgUrls == null)
            {
                return new SharedResponse<ProductImgUrlDto>(Status.notFound, null);

            }
            var ProductImgUrl = await db.ProductImgUrls.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            if (ProductImgUrl == null)
            {
                return new SharedResponse<ProductImgUrlDto>(Status.notFound, null);
            }
            ProductImgUrl.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<ProductImgUrlDto>(Status.noContent, null);
        }

       

        public async Task<SharedResponse<ProductImgUrlDto>> GetById(int Id)
        {
            if (db.ProductImgUrls == null)
            {
                return new SharedResponse<ProductImgUrlDto>(Status.notFound, null);
            }
            var ProductImgUrl = await db.ProductImgUrls.Where(c => c.Id == Id && c.IsDeleted == false).FirstOrDefaultAsync();
            if (ProductImgUrl == null)
                return new SharedResponse<ProductImgUrlDto>(Status.notFound, null);
            var ProductImgUrlDto = mapper.Map<ProductImgUrlDto>(ProductImgUrl);
            return new SharedResponse<ProductImgUrlDto>(Status.found, ProductImgUrlDto);
        }

        public async Task<SharedResponse<ProductImgUrlDto>> Update(int Id, ProductImgUrlDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<ProductImgUrlDto>(Status.badRequest, null);
            }

            ProductImgUrl ProductImgUrl = mapper.Map<ProductImgUrl>(model);

            db.Entry(ProductImgUrl).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<ProductImgUrlDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<ProductImgUrlDto>(Status.noContent, null);
        }

        public bool IsExists(int Id)
        {
            return (db.ProductImgUrls?.Any(a => a.Id == Id&&a.IsDeleted==false)).GetValueOrDefault();
        }

        public Task<SharedResponse<List<ProductImgUrlDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<SharedResponse<List<ProductImgUrlDto>>> GetImgUrlByProductId(int ProductId)
        {
             if (db.ProductImgUrls == null)
                return new SharedResponse<List<ProductImgUrlDto>>(Status.notFound, null);
            var ProductImgUrlDto = await db.ProductImgUrls.Where(a => a.ProductId == ProductId && a.IsDeleted == false).ToListAsync();
            List<ProductImgUrlDto> addresses = mapper.
            Map<List<ProductImgUrlDto>>(ProductImgUrlDto);
            return new SharedResponse<List<ProductImgUrlDto>>(Status.found, addresses);
        }
    }
}
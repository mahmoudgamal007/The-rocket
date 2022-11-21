using AutoMapper;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class ProductSizeRepo : IProductSizeRepo
    {

        private readonly IMapper mapper;
        private readonly TheRocketDbContext db;

        public ProductSizeRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<SharedResponse<ProductSizeDto>> AssignSizesToProdcut(ProductSizeDto model)
        {
            if (db.ProductSizes == null)
            {
                return new SharedResponse<ProductSizeDto>(Status.problem, null, "Entity 'db.ProductSizes' is null");
            }
            foreach (var sizeId in model.SizeIds)
            {
                ProductSize productSize = new() { ProductId = model.ProductId, SizeId = sizeId };
                db.ProductSizes.Add(productSize);
            }
            try
            {
                await db.SaveChangesAsync();
                return new SharedResponse<ProductSizeDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<ProductSizeDto>(Status.badRequest, null, ex.ToString());
            }
        }

        public async Task<SharedResponse<ProductSizeDto>> UnAssignSizesToProdcut(ProductSizeDto model)
        {
            if (db.ProductSizes == null)
            {
                return new SharedResponse<ProductSizeDto>(Status.noContent, null);
            }
            if (model.ProductId != null && model.SizeIds != null)
            {
                ProductSize[] productSizes = new ProductSize[model.SizeIds.Count()];
                for (int i = 0; i < model.SizeIds.Count(); i++)
                {
                    var productSize = db.ProductSizes.Where(p => p.ProductId == model.ProductId && p.SizeId == model.SizeIds[i]).FirstOrDefault();
                    productSizes[i] = productSize;
                }
                db.ProductSizes.RemoveRange(productSizes);
                try
                {
                    db.SaveChanges();
                    return new SharedResponse<ProductSizeDto>(Status.noContent, null);
                }
                catch (Exception ex)
                {
                    return new SharedResponse<ProductSizeDto>(Status.badRequest, null, ex.ToString());
                }

            }
            return new SharedResponse<ProductSizeDto>(Status.badRequest, null);


        }
    }
}
using AutoMapper;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class ProductColorRepo : IProductColorRepo
    {

        private readonly IMapper mapper;
        private readonly TheRocketDbContext db;

        public ProductColorRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<SharedResponse<ProductColorDto>> AssignColorsToProdcut(ProductColorDto model)
        {
            if (db.ProductColors == null)
            {
                return new SharedResponse<ProductColorDto>(Status.problem, null, "Entity 'db.ProductColors' is null");
            }
            if (model.ProductId != null && model.ColourIds != null)
            {
                foreach (var ColourId in model.ColourIds)
                {
                    ProductColor ProductColor = new() { ProductId = model.ProductId, ColourId = ColourId };
                    db.ProductColors.Add(ProductColor);
                }
                try
                {
                    await db.SaveChangesAsync();
                    return new SharedResponse<ProductColorDto>(Status.createdAtAction, model);
                }
                catch (Exception ex)
                {
                    return new SharedResponse<ProductColorDto>(Status.badRequest, null, ex.ToString());
                }
            }
            return new SharedResponse<ProductColorDto>(Status.badRequest, null);
        }

        public async Task<SharedResponse<ProductColorDto>> UnAssignColorsToProdcut(ProductColorDto model)
        {
            if (db.ProductColors == null)
            {
                return new SharedResponse<ProductColorDto>(Status.noContent, null);
            }
            if (model.ProductId != null && model.ColourIds != null)
            {
                ProductColor[] ProductColors = new ProductColor[model.ColourIds.Count()];
                for (int i = 0; i < model.ColourIds.Count(); i++)
                {
                    var ProductColor = db.ProductColors.Where(p => p.ProductId == model.ProductId && p.ColourId == model.ColourIds[i]).FirstOrDefault();
                    ProductColors[i] = ProductColor;
                }
                db.ProductColors.RemoveRange(ProductColors);
                try
                {
                    db.SaveChanges();
                    return new SharedResponse<ProductColorDto>(Status.noContent, null);
                }
                catch (Exception ex)
                {
                    return new SharedResponse<ProductColorDto>(Status.badRequest, null, ex.ToString());
                }

            }
            return new SharedResponse<ProductColorDto>(Status.badRequest, null);


        }
    }
}
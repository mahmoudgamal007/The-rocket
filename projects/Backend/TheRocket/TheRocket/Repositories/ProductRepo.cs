using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.QueryParameters;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class ProductRepo : IProdcutRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;
        private readonly IProductColorRepo colorRepo;
        private readonly IProductSizeRepo sizeRepo;
        private readonly IProductImgUrlRepo imgUrlRepo;
        private readonly ISellerRepo sellerRepo;

        public ProductRepo(TheRocketDbContext db, IMapper mapper, IProductColorRepo colorRepo, IProductSizeRepo sizeRepo, IProductImgUrlRepo imgUrlRepo, ISellerRepo sellerRepo)
        {
            this.sellerRepo = sellerRepo;
            this.db = db;
            this.mapper = mapper;
            this.colorRepo = colorRepo;
            this.sizeRepo = sizeRepo;
            this.imgUrlRepo = imgUrlRepo;
        }
        public async Task<SharedResponse<ProductDto>> Create(ProductDto model)
        {
            string message = "";
            if (db.Products == null)
            {
                return new SharedResponse<ProductDto>(Status.problem, null, "Entity Set 'db.Product' is null");
            }

            if (model == null) return new SharedResponse<ProductDto>(Status.badRequest, null);

            if (!sellerRepo.IsExists(model.SellerId))
                return new SharedResponse<ProductDto>(Status.notFound, null, "Seller Id not Found");

            Product Product = mapper.Map<Product>(model);

            if (Product == null) return new SharedResponse<ProductDto>(Status.problem, null);

            db.Products.Add(Product);
            try
            {
                db.SaveChanges();
                model.Id=Product.Id;
                SharedResponse<ProductColorDto> colorResponse;

                if (model.productColorDtos != null)
                {
                    model.productColorDtos.ProductId = model.Id;
                    colorResponse = await colorRepo.AssignColorsToProdcut(model.productColorDtos);
                    if (colorResponse.message != "") message += colorResponse.message + ", ";
                }

                SharedResponse<ProductSizeDto> sizeResponse;
                if (model.productSizeDtos != null)
                {
                    model.productSizeDtos.ProductId = model.Id;
                    sizeResponse = await sizeRepo.AssignSizesToProdcut(model.productSizeDtos);
                    if (sizeResponse.message != "") message += sizeResponse.message + ", ";
                }

                if (model.ProductImgUrlDto == null) return new SharedResponse<ProductDto>(Status.badRequest, null);

                SharedResponse<ProductImgUrlDto> imgUrlResponse;
                model.ProductImgUrlDto.ProductId = model.Id;
                imgUrlResponse = await imgUrlRepo.Create(model.ProductImgUrlDto);
                if (imgUrlResponse.message != null) message += imgUrlResponse.message + ", ";

                return new SharedResponse<ProductDto>(Status.createdAtAction, model, message);

            }
            catch (Exception ex)
            {
                return new SharedResponse<ProductDto>(Status.badRequest, null, ex.ToString());
            }
        }



        public async Task<SharedResponse<ProductDto>> Delete(int Id)
        {
            if (db.Products == null)
            {
                return new SharedResponse<ProductDto>(Status.notFound, null);

            }
            var Product = await db.Products.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            if (Product == null)
            {
                return new SharedResponse<ProductDto>(Status.notFound, null);
            }
            Product.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<ProductDto>(Status.noContent, null);
        }

        public Task<SharedResponse<List<ProductDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<SharedResponse<ProductDto>> GetById(int Id)
        {
            if (db.Products == null)
            {
                return new SharedResponse<ProductDto>(Status.notFound, null);
            }
            var product = await db.Products.Where(p => p.Id == Id && p.IsDeleted == false).FirstOrDefaultAsync();
            if (product == null)
                return new SharedResponse<ProductDto>(Status.notFound, null);
            var productDto = mapper.Map<ProductDto>(product);
            return new SharedResponse<ProductDto>(Status.found, productDto);
        }

        public async Task<SharedResponse<List<ProductDto>>> GetProductsWithFilters(ProductQueryParameter queryParameter)
        {
            if (db.Products == null)
                return new SharedResponse<List<ProductDto>>(Status.notFound, null);

            IQueryable<Product> products = db.Products.Where(p => p.IsDeleted == false);

            if (products == null)
                return new SharedResponse<List<ProductDto>>(Status.notFound, null);

            if (!string.IsNullOrEmpty(queryParameter.SearchTerm))
                products = products.Where(p => p.Name.ToLower().Contains(queryParameter.SearchTerm.ToLower()) ||
                p.Desctiption.ToLower().Contains(queryParameter.Desctiption.ToLower()));

            if (!string.IsNullOrEmpty(queryParameter.Name))
                products = products.Where(p => p.Name.ToLower() == queryParameter.Name.ToLower());

            if (queryParameter.MinPrice != null)
                products = products.Where(p => p.Price - (p.Price * p.Discount) >= queryParameter.MinPrice);

            if (queryParameter.MaxPrice != null)
                products = products.Where(p => p.Price - (p.Price * p.Discount) <= queryParameter.MaxPrice);

            products = products.Skip(queryParameter.Size * (queryParameter.Page - 1))
            .Take(queryParameter.Size);

            List<ProductDto> productDtos = mapper.Map<List<ProductDto>>(products);
            return new SharedResponse<List<ProductDto>>(Status.found, productDtos);

        }

        public bool IsExists(int Id)
        {
            return (db.Products?.Any(a => a.Id == Id && a.IsDeleted == false)).GetValueOrDefault();
        }

        public async Task<SharedResponse<ProductDto>> Update(int Id, ProductDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<ProductDto>(Status.badRequest, null);
            }

            Product Product = mapper.Map<Product>(model);

            db.Entry(Product).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<ProductDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return new SharedResponse<ProductDto>(Status.noContent, null);
        }


    }
}
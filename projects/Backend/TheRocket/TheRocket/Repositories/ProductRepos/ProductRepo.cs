using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.Extentions;
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
                model.Id = Product.Id;
                SharedResponse<ProductColorDto> colorResponse;

                if (model.Colors != null)
                {
                    ProductColorDto productColorDto = new();
                    foreach (var color in model.Colors)
                    {
                        productColorDto.ColourIds.Add(color.Id);
                    }
                    productColorDto.ProductId = model.Id;
                    colorResponse = await colorRepo.AssignColorsToProdcut(productColorDto);
                    if (colorResponse.message != "") message += colorResponse.message + ", ";
                }

                SharedResponse<ProductSizeDto> sizeResponse;
                if (model.Sizes != null)
                {
                    ProductSizeDto productSizeDto = new();
                    foreach (var Size in model.Sizes)
                    {
                        productSizeDto.SizeIds.Add(Size.Id);
                    }
                    productSizeDto.ProductId = model.Id;
                    sizeResponse = await sizeRepo.AssignSizesToProdcut(productSizeDto);
                    if (sizeResponse.message != "") message += sizeResponse.message + ", ";
                }


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

            var colorResponse = await colorRepo.GetColorsByProductId(productDto.Id);
            var sizeResponse = await sizeRepo.GetSizesByProductId(productDto.Id);
            productDto.Colors = colorResponse.data;
            productDto.Sizes = sizeResponse.data;

            return new SharedResponse<ProductDto>(Status.found, productDto);
        }

        public async Task<SharedResponse<GetAllProductDto>> GetProductsWithFilters(ProductQueryParameter queryParameter)
        {
            if (db.Products == null)
                return new SharedResponse<GetAllProductDto>(Status.notFound, null);

            var products = db.Products.Include(p => p.ProductColors).Include(p => p.ProductSizes).Include(p => p.Imgs).Where(p => p.IsDeleted == false);

            if (products == null)
                return new SharedResponse<GetAllProductDto>(Status.notFound, null);

            if (queryParameter.SellerId > 0)
            {
                products = products.Where(p => p.SellerId == queryParameter.SellerId && p.IsDeleted == false);
            }

            if (!string.IsNullOrEmpty(queryParameter.SortBy))
            {
                if (typeof(Product).GetProperty(queryParameter.SortBy) != null)
                {
                    products = products.OrderByCustom(
                        queryParameter.SortBy,
                        queryParameter.SortOrder);
                }
            }
            
            if (!string.IsNullOrEmpty(queryParameter.SearchTerm))
                products = products.Where(p => p.Name.ToLower().Contains(queryParameter.SearchTerm.ToLower()) ||
                p.Desctiption.ToLower().Contains(queryParameter.SearchTerm.ToLower()) ||
                p.SubCategory.Name.ToLower().Contains(queryParameter.SearchTerm.ToLower()) ||
                p.SubCategory.MainCategory.ToLower().Contains(queryParameter.SearchTerm.ToLower()));

            if (!string.IsNullOrEmpty(queryParameter.Name))
                products = products.Where(p => p.Name.ToLower() == queryParameter.Name.ToLower());

            if (queryParameter.MinPrice != null)
                products = products.Where(p => p.Price - (p.Price * p.Discount/100) >= queryParameter.MinPrice);

            if (queryParameter.MaxPrice != null)
                products = products.Where(p => p.Price - (p.Price * p.Discount/100) <= queryParameter.MaxPrice);
            var itemCount = products.Count();

            var startIndex = queryParameter.Size * (queryParameter.Page - 1) ;
            products = products.Skip(startIndex )
            .Take(queryParameter.Size);
            var endIndex = startIndex + products.Count();
            var response = products.ToList();
            List<ProductDto> productDtos = mapper.Map<List<ProductDto>>(response);
            foreach (var productDto in productDtos)
            {
                var colorResponse = await colorRepo.GetColorsByProductId(productDto.Id);
                var sizeResponse = await sizeRepo.GetSizesByProductId(productDto.Id);
                productDto.Colors = colorResponse.data;
                productDto.Sizes = sizeResponse.data;
            }


            

            return new SharedResponse<GetAllProductDto>(Status.found, new GetAllProductDto
            {
                products = productDtos,
                productMatchCount = itemCount,
                productPerPage = products.Count(),
                startIndex = startIndex+1,
                endIndex = endIndex
            });

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
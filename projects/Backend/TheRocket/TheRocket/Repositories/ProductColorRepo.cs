// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
// using TheRocket.Entities.ProductDtos;
// using TheRocket.Entities.Products;
// using TheRocket.Repositories.RepoInterfaces;
// using TheRocket.Shared;
// using TheRocket.TheRocketDbContexts;

// namespace TheRocket.Repositories
// {
//     public class ProductColorRepo : IProductColorRepo
//     {
//         private readonly TheRocketDbContext db;
//         private readonly IMapper mapper;
//         public ProductColorRepo(TheRocketDbContext db, IMapper mapper)
//         {
//             this.mapper = mapper;
//             this.db = db;

//         }
//        public async Task<SharedResponse<ProductColorDto>> Create(ProductColorDto model)
//         {


//             if (db.ProductColors == null)
//             {
//                 return new SharedResponse<ProductColorDto>(Status.problem, null, "Entity Set 'db.ProductColor' is null");
//             }
//             ProductColor productColor = mapper.Map<ProductColor>(model);
//             db.ProductColors.Add(productColor);
//             try
//             {
//                 await db.SaveChangesAsync();
//                 model = mapper.Map<ProductColorDto>(productColor);
//                 return new SharedResponse<ProductColorDto>(Status.createdAtAction, model);
//             }
//             catch (Exception ex)
//             {
//                 return new SharedResponse<ProductColorDto>(Status.badRequest, null, ex.ToString());
//             }

//         }

//         public async Task<SharedResponse<ProductColorDto>> Delete(int Id)
//         {
//             if (db.ProductColors == null)
//             {
//                 return new SharedResponse<ProductColorDto>(Status.notFound, null);

//             }
//             var productColor = await db.ProductColors.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
//             if (productColor == null)
//             {
//                 return new SharedResponse<ProductColorDto>(Status.notFound, null);
//             }
//             productColor.IsDeleted = true;
//             await db.SaveChangesAsync();
//             return new SharedResponse<ProductColorDto>(Status.noContent, null);
//         }

       

//         public Task<SharedResponse<ProductColorDto>> GetById(int Id)
//         {
//             throw new NotImplementedException();
//         }

//         public async Task<SharedResponse<ProductColorDto>> Update(int Id, ProductColorDto model)
//         {
//             if (Id != model.Id)
//             {
//                 return new SharedResponse<ProductColorDto>(Status.badRequest, null);
//             }

//             ProductColor productColor = mapper.Map<ProductColor>(model);

//             db.Entry(productColor).State = EntityState.Modified;

//             try
//             {
//                 if (IsExists(Id))
//                     await db.SaveChangesAsync();
//                 else
//                     return new SharedResponse<ProductColorDto>(Status.notFound, null);
//             }
//             catch (DbUpdateConcurrencyException)
//             {

//                 throw;
//             }

//             return new SharedResponse<ProductColorDto>(Status.noContent, null);
//         }

//         public bool IsExists(int Id)
//         {
//             return (db.ProductColors?.Any(a => a.Id == Id&&a.IsDeleted==false)).GetValueOrDefault();
//         }

//         public Task<SharedResponse<List<ProductColorDto>>> GetAll()
//         {
//             throw new NotImplementedException();
//         }

      
//     }
// }
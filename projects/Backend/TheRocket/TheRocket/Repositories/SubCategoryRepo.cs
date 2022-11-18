using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos;
using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class SubCategoryRepo : ISubCategory
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper _mapper;
        public SubCategoryRepo( TheRocketDbContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<SubCategory> Create(SubCategoryDto subCategory)
        {
            var s = new SubCategory();
            _mapper.Map(subCategory, s);
            db.SubCategories.Add(s);
            await db.SaveChangesAsync();
            return s;
        }

        public async Task<SubCategory> Update(SubCategoryDto subCategory)
        {
            var SubCategory = new SubCategory();
            var s = await db.SubCategories.FirstOrDefaultAsync(s => s.Id == subCategory.Id && s.IsDeleted == false);
            _mapper.Map(subCategory,s);
            await db.SaveChangesAsync();
            return s;
        }


        public async Task< List<SubCategory>> GetAll()
        {
            return await db.SubCategories.Include(s => s.products).Where(p => p.IsDeleted == false).ToListAsync();
        }
   
        public async Task< List<Product> >GetAllProducts()
        {
            return await db.Products.Where(p => p.IsDeleted == false).ToListAsync();
        }
      
        public async Task<SubCategory> GetById(int id)
        {    
            return await db.SubCategories.SingleOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);

        }

        public async Task<List<SubCategory>> Delete(int id)
        {
            var p = await db.SubCategories.FirstOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);
            p.IsDeleted = true;
            await db.SaveChangesAsync();
            return await db.SubCategories.Where(s => s.IsDeleted == false).ToListAsync();
        }
    }
}

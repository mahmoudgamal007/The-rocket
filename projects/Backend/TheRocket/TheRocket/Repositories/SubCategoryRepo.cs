using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<SubCategory> Add(SubCategory subCategory)
        {
            db.SubCategories.Add(subCategory);
            await db.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> Update(SubCategory subCategory)
        {
            var s = await db.SubCategories.FirstOrDefaultAsync(s => s.Id == subCategory.Id);
            _mapper.Map(s, subCategory);
            return subCategory;
        }

    
        public async Task< List<SubCategory>> GetAll()
        {

            return await db.SubCategories.Include(s => s.products).ToListAsync();
        }
   
        public async Task< List<Product> >GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }
      
        public async Task<SubCategory> GetById(int id)
        {    
            return await db.SubCategories.SingleOrDefaultAsync(s => s.Id == id);

        }


    }
}

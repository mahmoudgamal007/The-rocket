using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos;
using TheRocket.Entities;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;
namespace TheRocket.Repositories
{
    public class SubCategoryRepo : ISubCategory
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper _mapper;
        public SubCategoryRepo( TheRocketDbContext context, IMapper mapper)
        {
           this.db = context;
          this._mapper = mapper;
        }

        public bool IsExists(int Id)
        {
            return (db.SubCategories?.Any(a => a.Id == Id && a.IsDeleted ==false)).GetValueOrDefault();
        }

        public async Task<SharedResponse<SubCategoryDto>> Create(SubCategoryDto model)
        {
            if (db.SubCategories ==null)
            {
                return new SharedResponse<SubCategoryDto>(Status.problem, null, "db.SubCategories is null");
            }
            SubCategory subCategory = _mapper.Map<SubCategory>(model);
            db.SubCategories.Add(subCategory);
            try{

            await db.SaveChangesAsync();
            model= _mapper.Map<SubCategoryDto>(subCategory);
            return new SharedResponse<SubCategoryDto>(Status.createdAtAction,model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<SubCategoryDto>(Status.badRequest, null, ex.ToString());
            }
        }

        public async Task<SharedResponse<SubCategoryDto>> Update(int Id,SubCategoryDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<SubCategoryDto>(Status.badRequest, null);
            }

            SubCategory subCategory = _mapper.Map<SubCategory>(model);
            db.Entry(subCategory).State = EntityState.Modified;

           try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<SubCategoryDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<SubCategoryDto>(Status.noContent, null);
       
        }



        public async Task<SharedResponse<List<SubCategoryDto>>> GetAll()
        {
              if (db.SubCategories ==null)
            {
                return  new SharedResponse<List<SubCategoryDto>>(Status.notFound, null);
            }

            var subCategoryDto = await db.SubCategories.Where( s => s.IsDeleted == false).ToListAsync();
            List<SubCategoryDto> subCategories = _mapper.Map<List<SubCategoryDto>>(subCategoryDto);   
            return  new  SharedResponse<List<SubCategoryDto>>(Status.found,subCategories);
        }
   
        public async Task<SharedResponse<SubCategoryDto> >GetById(int id)
        {  
               if (db.SubCategories ==null)
            {
                return  new SharedResponse<SubCategoryDto>(Status.notFound, null, "db.SubCategory is null");
            }
            var subCategory = await db.SubCategories.SingleOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
              if (subCategory == null)
            {
                return new SharedResponse<SubCategoryDto>(Status.notFound, null);
            }
             var  model= _mapper.Map<SubCategoryDto>(subCategory);

            return new SharedResponse<SubCategoryDto>(Status.found,model);
       
        }

        public async Task<SharedResponse<SubCategoryDto>> Delete(int id)
        {
          if (db.SubCategories ==null)
            {
                return new SharedResponse<SubCategoryDto>(Status.notFound, null, "db.SubCategory is null");
            }

            var subCategory = await db.SubCategories.SingleOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
              if (subCategory == null)
            {
                return new SharedResponse<SubCategoryDto>(Status.notFound, null);
            }
            subCategory.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<SubCategoryDto>(Status.noContent,null);
        }

       

        
    }
}

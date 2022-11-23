using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.UserDtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.Entities;
using TheRocket.TheRocketDbContexts;
using TheRocket.Entities.Users;

namespace TheRocket.Repositories
{
     public class LocationRepo : ILocationRepo
    {

        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;

        public LocationRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<SharedResponse<LocationDto>> Create(LocationDto model)
        {


            if (db.Locations == null)
            {
                return new SharedResponse<LocationDto>(Status.problem, null, "Entity Set 'db.Locations' is null");
            }
            
            Location Locations = mapper.Map<Location>(model);
            db.Locations.Add(Locations);
            try
            {
                await db.SaveChangesAsync();
                model = mapper.Map<LocationDto>(Locations);
                return new SharedResponse<LocationDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<LocationDto>(Status.badRequest, null, ex.ToString());
            }

        }

        public async Task<SharedResponse<LocationDto>> Delete(int Id)
        {
            if (db.Locations == null)
            {
                return new SharedResponse<LocationDto>(Status.notFound, null);

            }
            var Locations = await db.Locations.Where(l=>l.Id == Id && l.IsDeleted == false).FirstOrDefaultAsync();
            if (Locations == null)
            {
                return new SharedResponse<LocationDto>(Status.notFound, null);
            }
            Locations.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<LocationDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<LocationDto>>> GetLocationsByUserId(string AppUserId)
        {
            if (db.Locations == null)
                return new SharedResponse<List<LocationDto>>(Status.notFound, null);
            var LocationssDto = await db.Locations.Where(l=>l.AppUserId == AppUserId && l.IsDeleted == false).ToListAsync();
            List<LocationDto> Locationss = mapper.
            Map<List<LocationDto>>(LocationssDto);
            return new SharedResponse<List<LocationDto>>(Status.found, Locationss);
        }

       

        public async Task<SharedResponse<LocationDto>> GetById(int Id)
        {
            if (db.Locations == null)
                return new SharedResponse<LocationDto>(Status.notFound, null);
            var LocationDto = await db.Locations.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            LocationDto Location = mapper.
            Map<LocationDto>(LocationDto);
            return new SharedResponse<LocationDto>(Status.found, Location);
        }

        public async Task<SharedResponse<LocationDto>> Update(int Id, LocationDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<LocationDto>(Status.badRequest, null);
            }

            Location Locations = mapper.Map<Location>(model);

            db.Entry(Locations).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<LocationDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<LocationDto>(Status.noContent, null);
        }

        public bool IsExists(int Id)
        {
            return (db.Locations?.Any(l => l.Id == Id&&l.IsDeleted==false)).GetValueOrDefault();
        }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD:projects/Backend/TheRocket/TheRocket/Repositories/LocationRepo.cs
        public Task<SharedResponse<List<LocationDto>>> GetAll()
=======
        public async Task<SharedResponse<List<LocationDto>>> GetAll()
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9:projects/Backend/TheRocket/TheRocket/Repositories/UserRepos/LocationRepo.cs
=======
        public async Task<SharedResponse<List<LocationDto>>> GetAll()
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
        public async Task<SharedResponse<List<LocationDto>>> GetAll()
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
        {
             if (db.Locations == null)
                return new SharedResponse<List<LocationDto>>(Status.notFound, null);
            var LocationsDto = await db.Locations.Where(a => a.IsDeleted == false).ToListAsync();
            List<LocationDto> Locations = mapper.
            Map<List<LocationDto>>(LocationsDto);
            return new SharedResponse<List<LocationDto>>(Status.found, Locations);
        }
    }
}
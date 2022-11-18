using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    [Authorize(Roles="Buyer,Seller")]

    public class AddressController : ControllerBase
    {
        private readonly IAddressRepo repo;
        public AddressController(IAddressRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressDto>>> GetAddressByUserId(String userId){
         SharedResponse<List<AddressDto>> response= await repo.GetAddressesByUserId(userId);
         if(response.status==Status.notFound)return NotFound();
         return response.data;
        }

        [HttpPost]
        public async Task<ActionResult<AddressDto>> PostAddress(AddressDto address){
            SharedResponse<AddressDto> response=await repo.Create(address);
            if(response.status==Status.problem)return Problem(response.message);
            return Ok(response.data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddressDto>> PutAddress(int id,AddressDto address){
            SharedResponse<AddressDto> response=await repo.Update(id,address);
            if(response.status==Status.badRequest)return BadRequest();
            else if(response.status==Status.notFound)return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
         public async Task<ActionResult<AddressDto>> DeleteAddress(int id){
            SharedResponse<AddressDto> response=await repo.Delete(id);
            if(response.status==Status.notFound)return NotFound();
            return NoContent();
         } 
    }
}
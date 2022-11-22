using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Entities;
using TheRocket.Dtos;
using TheRocket.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos.UserDtos;
using TheRocket.Shared;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using T.Repositories;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Seller")]

    public class SubscripsController : ControllerBase
    {
        private readonly ISubscripRepo subscripRepo;

        public SubscripsController(ISubscripRepo subscripRepo)
        {
            this.subscripRepo = subscripRepo;
        }

        //GetAll

        [HttpGet]
    [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAll()
        {
            SharedResponse<List<SubscripDto>> response = await subscripRepo.GetAll();
            if (response.status == Status.notFound) { return NotFound(); }
            else { return Ok(response.data); }
        }


        // GetById
       [HttpGet("[action]")]
            public async Task<ActionResult<SubscripDto>> GetById([FromQuery]int Id)
        { 
            SharedResponse<SubscripDto> response = await subscripRepo.GetById(Id);
            if (response.status == Status.notFound) return NotFound();
            return response.data;
        }

       // post
  
        [HttpPost]
        public async Task<ActionResult<SubscripDto>> Create(SubscripDto subscrip)
        {
            SharedResponse<SubscripDto> response = await subscripRepo.Create(subscrip);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }
        //put
        [HttpPut]
        public async Task<ActionResult<SubscripDto>> Update([FromQuery]int Id, SubscripDto subscrip)
        {
            SharedResponse<SubscripDto> response = await subscripRepo.Update(Id, subscrip);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
        //Delete
        [HttpDelete]
        public async Task<ActionResult<SubscripDto>> Delete([FromQuery]int Id)
        {
            SharedResponse<SubscripDto> response = await subscripRepo.Delete(Id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }

}

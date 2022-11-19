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

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Buyer")]

    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackRepo feedbackRepo;

        public FeedbacksController(IFeedbackRepo feedbackRepo)
        {
            this.feedbackRepo = feedbackRepo;
        }

        //GetAllFeedbacks

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            SharedResponse<List<FeedbackDto>> response = await feedbackRepo.GetAllFeedbacks();
            if (response.status == Status.notFound) { return NotFound(); }
            else { return Ok(response.data); }
        }


        // GetById
        [HttpGet("{ProuductId}/{BuyerId}")]
            public async Task<ActionResult<List<FeedbackDto>>> GetFeedbackById([FromRoute] int ProuductId, [FromRoute] int BuyerId)
        { 
            SharedResponse<List<FeedbackDto>> response = await feedbackRepo.GetFeedbackbyId(ProuductId, BuyerId);
            if (response.status == Status.notFound) return NotFound();
            return response.data;
        }

       // post
  
        [HttpPost]
        public async Task<ActionResult<FeedbackDto>> Create(FeedbackDto feedback)
        {
            SharedResponse<FeedbackDto> response = await feedbackRepo.Create(feedback);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }
        //put
        [HttpPut("{ProductId}/{BuyerId}")]
        public async Task<ActionResult<FeedbackDto>> UpdateFeedback(int ProductId, int BuyerId, FeedbackDto feedback)
        {
            SharedResponse<FeedbackDto> response = await feedbackRepo.UpdateFeedback(ProductId, BuyerId, feedback);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
        //Delete
        [HttpDelete("{ProductId}/{BuyerId}")]
        public async Task<ActionResult<FeedbackDto>> DeleteFeedback(int ProductId, int BuyerId)
        {
            SharedResponse<FeedbackDto> response = await feedbackRepo.DeleteFeedback(ProductId, BuyerId);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }

}

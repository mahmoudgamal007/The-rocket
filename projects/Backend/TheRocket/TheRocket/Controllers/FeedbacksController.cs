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




namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(await feedbackRepo.GetAllFeedbacks());
        }


        //GetById
        [HttpGet("{ProuductId}/{BuyerId}")]
        public async Task<IActionResult> GetById([FromRoute] int ProuductId, [FromRoute] int BuyerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = await feedbackRepo.GetById(BuyerId, ProuductId);

            if (feedback == null)
            {
                return NotFound();
            }   
            
            return Ok(feedback);
        }
        //post
        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackDto feedback)
        {
            return Ok(await feedbackRepo.AddFeedback(feedback));
        }
        
        //put
        [HttpPut("{ProductId}/{BuyerId}")]
        public async Task<IActionResult> UpdateFeedback(int ProductId,int BuyerId, FeedbackDto feedback)
        {
            return Ok ( await feedbackRepo.UpdateFeedback(ProductId, BuyerId,feedback));
       
            }
        } 
}

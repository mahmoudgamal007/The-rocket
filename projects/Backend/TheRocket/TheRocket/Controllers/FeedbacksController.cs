using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetAll()
        {
            SharedResponse<List<FeedbackDto>> response = await feedbackRepo.GetAll();
            if (response.status == Status.notFound) { return NotFound(); }
            else { return Ok(response.data); }
        }
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllFeedbacsByProductId([FromQuery] int productId)
        {
            var response=await feedbackRepo.GetAllFeedbacsByProductId(productId);
            if (response.status == Status.notFound) { return NotFound(); }
            else { return Ok(response.data); }
        }

        // GetById
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin,Seller")]

        public async Task<ActionResult<FeedbackDto>> GetById([FromQuery] int Id)
        {
            SharedResponse<FeedbackDto> response = await feedbackRepo.GetById(Id);
            if (response.status == Status.notFound) return NotFound();
            return response.data;
        }

        // post

        [HttpPost]
        [Authorize(Roles = "Buyer")]

        public async Task<ActionResult<FeedbackDto>> Create(FeedbackDto feedback)
        {
            SharedResponse<FeedbackDto> response = await feedbackRepo.Create(feedback);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }
        //put
        [HttpPut]
        [Authorize(Roles = "Buyer")]

        public async Task<ActionResult<FeedbackDto>> Update([FromQuery] int Id, FeedbackDto feedback)
        {
            SharedResponse<FeedbackDto> response = await feedbackRepo.Update(Id, feedback);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
        //Delete
        [HttpDelete]
        [Authorize(Roles = "Admin,Buyer")]

        public async Task<ActionResult<FeedbackDto>> Delete([FromQuery] int Id)
        {
            SharedResponse<FeedbackDto> response = await feedbackRepo.Delete(Id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }

}

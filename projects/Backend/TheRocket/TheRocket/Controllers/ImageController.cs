using Microsoft.AspNetCore.Mvc;
using TheRocket.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepo repo;
        public ImageController(IImageRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost,DisableRequestSizeLimit]
        public  ActionResult Upload(){
            var files=Request.Form.Files.ToList();
            if(!(files.Count>0))return BadRequest();
            var folderName=Path.Combine("Resources","Images");
            var pathToSave=Path.Combine(Directory.GetCurrentDirectory(),folderName);
            var response=repo.Upload(files,folderName,pathToSave);
            if(response.status==Status.createdAtAction)return Ok(response.data);
            if(response.status==Status.badRequest)return BadRequest();
            return StatusCode(500,"Internal Server Error"+response.message);
        }
    }
}
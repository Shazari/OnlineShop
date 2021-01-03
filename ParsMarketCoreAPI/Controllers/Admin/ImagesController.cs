using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.IO;
namespace ParsMarketCoreAPI.Controllers.Admin
{
    [Route("[controller]")]
    [ApiController]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class ImagesController : ControllerBase
    {
        public ImagesController(IHostEnvironment Env)
        {
            _env = Env;
        }
        private readonly IHostEnvironment _env;

        [HttpPost]
        public async Task<IActionResult> PostImage([FromForm] IFormFile image)
        {
            if (image==null||image.Length==0)
            {
                return BadRequest("upload a file");
            }
            string name = image.FileName;
            string extention = Path.GetExtension(name);
            string[] allowExtentions = { ".jpg",".png",".bmp",".jpeg" };

            if (!allowExtentions.Contains(extention))
            {
                return BadRequest("file is  not a valid image");
            }
            string fileName = $"{Guid.NewGuid()}{extention}";
            string filePath = Path.Combine(_env.ContentRootPath,"wwwroot","Images",fileName);
            using (var fileStream=new FileStream(filePath,FileMode.Create,FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
                
            }
            string u = "Images";
            return Ok($"{u}/{fileName}");

        }
        [HttpPut]
        public async Task<IActionResult> PutImage([FromForm]IFormFile image)
        {
           
            if (image == null || image.Length == 0)
            {
                return BadRequest("upload a file");
            }
            string name = image.FileName;
            string extention = Path.GetExtension(name);
            string[] allowExtentions = { ".jpg", ".png", ".bmp", ".jpeg" };

            if (!allowExtentions.Contains(extention))
            {
                return BadRequest("file is  not a valid image");
            }
            string fileName = $"{Guid.NewGuid()}{extention}";
            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot", "Images", fileName);
            
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);

            }
            
            string u = "Images";
            return Ok($"{u}/{fileName}");
        }
    }
}

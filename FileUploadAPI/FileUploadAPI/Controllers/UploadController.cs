using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUploadAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpGet("GetFileData/{id}")]
        public ActionResult<string> GetFileData(int id)
        {
            return "File with ID: " + id + ", is here:"; 
        }

        [HttpPost("SetConfigValues")]
        public void SetConfigValues()
        {

        }

        [HttpPost("UploadFile")]
        public async Task<ActionResult> UploadFileAsync([FromForm]CreateFile model)
        {
            try
            {
                if (model.File == null || model.File.Length == 0)
                {
                    return Content("File not Selected");
                }

                /*Code to upload files to a path*/
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", model.File.FileName);
                //Path should be set via Cofig Keys

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }
                /*File upload code ends*/
                     
                /*Code to store meta data in DB*/


                /*DB code ends*/
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }            
        }

        //
        //
    }
}
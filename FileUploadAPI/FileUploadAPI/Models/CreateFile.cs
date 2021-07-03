using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadAPI.Models
{
    public class CreateFile
    {
        public string FileAltText { get; set; }

        public string FileName { get; set; }

        public IFormFile File { get; set; }
    }
}

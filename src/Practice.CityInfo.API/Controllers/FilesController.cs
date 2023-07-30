using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Practice.CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    [Authorize]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var filePath = Path.Combine("C:\\Users\\Anja Reddy Gaddam\\source\\repos\\Practice\\src\\Practice.CityInfo.API\\Files\\TextFile.txt");
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);
            if (!_fileExtensionContentTypeProvider.TryGetContentType(filePath, out string contentType)) {
                contentType = "application/octet-stream";
            }

            return File(bytes, contentType, Path.GetFileName(filePath));
        }


        /// <summary>
        /// This is just to demonstrate how to use an instance of a service that is created by 
        /// Dependency Injection inside an action method directly without injecting at 
        /// controller level.
        /// </summary>
        /// <param name="fileExtensionContentTypeProvider"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        //[HttpGet("{fileId}", Name = "InjectingServicesIntoActionDemo")]
        //public ActionResult InjectingServicesIntoActionDemo([FromServices] FileExtensionContentTypeProvider fileExtensionContentTypeProvider, string fileId)
        //{
        //    var filePath = Path.Combine("C:\\Users\\Anja Reddy Gaddam\\source\\repos\\Practice\\src\\Practice.CityInfo.API\\Files\\TextFile.txt");
        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        return NotFound();
        //    }

        //    var bytes = System.IO.File.ReadAllBytes(filePath);
        //    _fileExtensionContentTypeProvider.TryGetContentType(filePath, out string contentType);
        //    return File(bytes, contentType, Path.GetFileName(filePath));
        //}
    }
}

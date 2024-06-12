using DATA_DuAn.DTO.ImageRequestDTO;
using DATA_DuAn.Models;
using DuAnWeb_QLNX.Repository.ImageRepository;
using Microsoft.AspNetCore.Mvc;

namespace DuAnWeb_QLNX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void ValidateUpload(ImageUpLoadRequestDTO request)
        {
            //var allowExtension = new string[] { ".jpg", ".jpeg", ".png" };
            //if (!allowExtension.Contains(Path.GetExtension(request.FileName)))
            //{
            //    ModelState.AddModelError("file", "Unsupported file extension");
            //}

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size too big, please upload file < 10M");
            }

        }

        [HttpPost("Upload")]
        public IActionResult Upload([FromForm] ImageUpLoadRequestDTO request)
        {
            ValidateUpload(request);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };
                imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("AllInfo")]
        public IActionResult GetAllInfoImages()
        {
            var allImages = imageRepository.GetAllInfoImages();
            return Ok(allImages);
        }

        [HttpGet("Download/{id}")]
        public IActionResult DownloadImages(int id)
        {
            var result = imageRepository.DownloadFile(id);
            return File(result.Item1, result.Item2, result.Item3);
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace DATA_DuAn.DTO.ImageRequestDTO
{
    public class ImageUpLoadRequestDTO
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
    }
}

using DATA_DuAn.Data;
using DATA_DuAn.Models;

namespace DuAnWeb_QLNX.Repository.ImageRepository
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CarRentalDbContext _carRentalDbContext;
        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, CarRentalDbContext carRentalDb)
        {
            _webHostEnviroment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _carRentalDbContext = carRentalDb;
        }//contructor

        public Image Upload(Image image)
        {
            var localFilePath = Path.Combine(_webHostEnviroment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

            using var stream = new FileStream(localFilePath, FileMode.Create);
            image.File.CopyTo(stream);

            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;

            _carRentalDbContext.SaveChanges();
            return image;
        }

        public List<Image> GetAllInfoImages()
        {
            var allImages = _carRentalDbContext.Images.ToList();
            return allImages;
        }

        public (byte[], string, string) DownloadFile(int Id)
        {
            try
            {
                var FileById = _carRentalDbContext.Images.Where(x => x.Id == Id).FirstOrDefault();
                var path = Path.Combine(_webHostEnviroment.ContentRootPath, "Images", $"{FileById.FileName}{FileById.FileExtension}");
                var stream = File.ReadAllBytes(path);
                var fileName = FileById.FileName + FileById.FileExtension;
                return (stream, "application/octet-sream", fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

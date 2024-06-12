using DATA_DuAn.Models;

namespace DuAnWeb_QLNX.Repository.ImageRepository
{
    public interface IImageRepository
    {
        Image Upload(Image image);
        List<Image> GetAllInfoImages();
        (byte[], string, string) DownloadFile(int Id);
    }
}

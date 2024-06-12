namespace DuAnWeb_QLNX.Repository.LoginRepository
{
    public interface IApiService
    {
        Task<string> GetTokenAsync(string email, string password);
    }
}

using CrudApi.DTOs;

namespace CrudApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(string username, string password);
    }
}

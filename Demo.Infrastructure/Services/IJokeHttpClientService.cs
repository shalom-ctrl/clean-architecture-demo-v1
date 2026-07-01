using Demo.Domain.Models;

namespace Demo.Infrastructure.Services
{
    public interface IJokeHttpClientService
    {
        Task<JokeModel> GetData();
    }
}
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Abstractions.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}

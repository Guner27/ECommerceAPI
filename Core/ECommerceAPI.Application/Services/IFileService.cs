using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Services
{
    public interface IFileService
    {
        /// <summary>
        /// Dosyalar wwwroot klasörü altına depolanacak. Sana dosya adlarını ve dosya yolunu döndüreceğim.
        /// </summary>
        /// <param name="path">Dosya yolunu nereye oluşturmak istersin</param>
        /// <param name="files">Requestden gelen dosyaları ver bana</param>
        /// <returns></returns>
        Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files);
        
        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}

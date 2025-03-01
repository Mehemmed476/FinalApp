using Microsoft.AspNetCore.Http;

namespace FinalApp.BL.ExternalServices.Abstractions;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile imageFile, string envPath, string[] allowedFileExtensions);
    void DeleteFile(string fileNameWithExtension, string envPath);
}
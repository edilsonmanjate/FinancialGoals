namespace FinancialGoals.Application.Services;

public interface IAzureBloobStorageService
{
    Task<string> UploadFileAsync(string containerName, string filePath);
    Task<byte[]> DownloadFileAsync(string containerName, string fileName);
    Task DeleteFileAsync(string containerName, string fileName);
    Task CreateContainerAsync(string containerName);
    Task<bool> ContainerExistsAsync(string containerName);
}

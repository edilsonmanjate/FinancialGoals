namespace FinancialGoals.Application.Services;

public interface IAzureBloobStorageService
{
    Task<string> UploadFileAsync(string containerName, string filePath);
    Task<byte[]> DownloadFileAsync(string containerName, string fileName);
    Task DeleteFileAsync(string containerName, string fileName);
    Task DeleteContainerAsync(string containerName);
    Task CreateContainerAsync(string containerName);
    Task<bool> ContainerExistsAsync(string containerName);
    Task<bool> FileExistsAsync(string containerName, string fileName);
    Task<IEnumerable<string>> ListFilesAsync(string containerName);
    Task<IEnumerable<string>> ListContainersAsync();
}

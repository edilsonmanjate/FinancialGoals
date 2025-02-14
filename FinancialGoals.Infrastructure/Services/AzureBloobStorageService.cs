using Azure.Identity;
using Azure.Storage.Blobs;

using FinancialGoals.Application.Services;

namespace FinancialGoals.Infrastructure.Services;

public class AzureBloobStorageService : IAzureBloobStorageService
{
    public Task<bool> ContainerExistsAsync(string containerName)
    {
        throw new NotImplementedException();
    }

    public Task CreateContainerAsync(string containerName)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }

    public Task<byte[]> DownloadFileAsync(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadFileAsync(string containerName, string filePath)
    {
        throw new NotImplementedException();
    }
}

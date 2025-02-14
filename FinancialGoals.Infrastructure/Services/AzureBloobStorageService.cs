using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using FinancialGoals.Application.Services;

namespace FinancialGoals.Infrastructure.Services;

public class AzureBloobStorageService : IAzureBloobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureBloobStorageService(string blobServiceEndpoint, string clientId, string clientSecret, string tenantId)
    {
        var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        _blobServiceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), credential);
    }

    public async Task<bool> ContainerExistsAsync(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return await containerClient.ExistsAsync();
    }

    public async Task CreateContainerAsync(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);
    }

    public async Task DeleteFileAsync(string containerName, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }

    public async Task<byte[]> DownloadFileAsync(string containerName, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        var downloadInfo = await blobClient.DownloadAsync();

        using (var memoryStream = new MemoryStream())
        {
            await downloadInfo.Value.Content.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }

    public async Task<string> UploadFileAsync(string containerName, string filePath)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(Path.GetFileName(filePath));

        await using var fileStream = File.OpenRead(filePath);
        await blobClient.UploadAsync(fileStream, true);

        return blobClient.Uri.ToString();
    }
}

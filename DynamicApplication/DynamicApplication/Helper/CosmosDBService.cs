using DynamicApplication.Model;
using Microsoft.Azure.Cosmos;

public class CosmosDBService
{
    private IConfiguration _configuration;
    private CosmosClient _cosmosClient;
    public CosmosDBService(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = _configuration?.GetConnectionString("CosmosDB");
        CosmosClient cosmosClient = new CosmosClient(connectionString);
    }


    public async Task CreateOrUpdateItemAsync<T>(T item, string partitionKey, string databaseName, string containerName)
    {
        Container container = _cosmosClient.GetContainer(databaseName, containerName);
        await container.UpsertItemAsync(item, new PartitionKey(partitionKey));
    }

    public async Task GetItemsAsync(string query)
    {
        
    }


}
using DynamicApplication.Interfaces;
using DynamicApplication.Model;

namespace DynamicApplication.Services
{
    public class QuestionService : IQuestion
    {
        private IConfiguration _configuration;
        private CosmosDBService _cosmosDBService;
        private string _cosmosDbName;
        private string _cosmosDbContainerName;
        public QuestionService(IConfiguration configuration, CosmosDBService cosmosDBService)
        {
            _configuration = configuration;
            _cosmosDBService = cosmosDBService;
            _cosmosDbName = _configuration[""];
            _cosmosDbContainerName = _configuration[""];
        }

        public async Task AddQuestionAsync(Questions question)
        {
            question.Id = Guid.NewGuid().ToString();
            await _cosmosDBService.CreateOrUpdateItemAsync(question, question.Id, _cosmosDbName, _cosmosDbContainerName);
        }

        public async Task AddMultipleQuestionsAsync(List<Questions> questions)
        {
            List<Task> concurrentTask = new List<Task>();

            foreach (var item in questions)
            {
                item.Id = Guid.NewGuid().ToString();
                concurrentTask.Add(_cosmosDBService.CreateOrUpdateItemAsync(item, item.Id, _cosmosDbName, _cosmosDbContainerName));
            }

            await Task.WhenAll(concurrentTask);
        }

        public Task DeleteQuestionByIdAsync(Questions question)
        {
            throw new NotImplementedException();
        }

        public Task<List<Questions>> GetQuestionsByProgramIdAsync(string programId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateQuestionByIdAync(Questions question)
        {
            await _cosmosDBService.CreateOrUpdateItemAsync(question, question.Id, _cosmosDbName, _cosmosDbContainerName);
        }
    }
}

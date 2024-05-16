using DynamicApplication.Interfaces;
using DynamicApplication.Model;

namespace DynamicApplication.Services
{
    public class ProgramService : IProgram
    {
        private IConfiguration _configuration;
        private CosmosDBService _cosmosDBService;
        private readonly IQuestion _question;
        private string _cosmosDbName;
        private string _cosmosDbContainerName;
        public ProgramService(IConfiguration configuration, CosmosDBService cosmosDBService, IQuestion question)
        {
            _configuration = configuration;
            _cosmosDBService = cosmosDBService;
            _cosmosDbName = _configuration[""];
            _cosmosDbContainerName = _configuration[""];
            _question = question;
        }
        public async Task CreateProgramAsync(ProgramForm programForm)
        {
            Guid newGuid = Guid.NewGuid();
           
            ProgramFields program = new()
            {
                Id = newGuid.ToString(),
                ProgramId = newGuid.ToString(),
                ProgramName = programForm.ProgramName,
                ProgramDesc = programForm.ProgramDesc,
                FormFields = programForm.FormFields

            };

            await _cosmosDBService.CreateOrUpdateItemAsync(program, program.ProgramId, _cosmosDbName, _cosmosDbContainerName);

            programForm.Questions.ForEach(x => x.ProgramId = newGuid.ToString());

            await _question.AddMultipleQuestionsAsync(programForm.Questions);


        }

        public async Task<ProgramForm> GetProgramByIdAsync(string programFormId)
        {
            throw new NotImplementedException();
        }
    }
}

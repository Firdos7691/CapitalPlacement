using DynamicApplication.Model;

namespace DynamicApplication.Interfaces
{
    public interface IQuestion
    {
        Task AddMultipleQuestionsAsync(List<Questions> questions);
        Task AddQuestionAsync(Questions question);
        Task<List<Questions>> GetQuestionsByProgramIdAsync(string programId);

        Task UpdateQuestionByIdAync(Questions question);
        Task DeleteQuestionByIdAsync(Questions question);
    }
}

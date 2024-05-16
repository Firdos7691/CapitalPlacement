using DynamicApplication.Model;

namespace DynamicApplication.Interfaces
{
    public interface IProgram
    {
        Task CreateProgramAsync(ProgramForm programForm);
        Task<ProgramForm> GetProgramByIdAsync(string programFormId);
    }
}

using DynamicApplication.Interfaces;
using DynamicApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private IProgram _program;
        public ProgramController(IProgram program)
        {
                _program = program;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> CreateProgram(ProgramForm programForm)
        {
            // Logic to save the item to the database or perform other actions
            // For demonstration, let's just return the created item
            await _program.CreateProgramAsync(programForm);

            return new HttpResponseMessage {StatusCode = System.Net.HttpStatusCode.Created};
        }
    }
}

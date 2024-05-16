using System.Text.Json.Serialization;

namespace DynamicApplication.Model
{
    public class Questions
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("programId")]
        public string ProgramId { get; set; } = string.Empty;

        [JsonPropertyName("questionTypeId")]
        public string QuestionTypeId { get; set; } = string.Empty;

        [JsonPropertyName("questionType")]
        public string QuestionType { get; set; } = string.Empty;

        [JsonPropertyName("question")]
        public string Question { get; set; } = string.Empty;

        [JsonPropertyName("choices")]
        public string[] Choices { get; set; }
    }
}
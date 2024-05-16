using System.Text.Json.Serialization;

namespace DynamicApplication.Model
{
    public class ProgramForm : ProgramFields
    { 

        [JsonPropertyName("questions")]
        public List<Questions> Questions { get; set; } = new List<Questions>();
    }

    public class ProgramFields
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("programId")]
        public string ProgramId { get; set; } = string.Empty;

        [JsonPropertyName("programName")]
        public string ProgramName { get; set; } = string.Empty;

        [JsonPropertyName("programDesc")]
        public string ProgramDesc { get; set; } = string.Empty;

        [JsonPropertyName("formFields")]
        public List<FormFields> FormFields { get; set; } = new List<FormFields>();
    }

    public class FormFields
    {
        [JsonPropertyName("fieldName")]
        public string FieldName { get; set; } = string.Empty;

        [JsonPropertyName("isMandatory")]
        public bool IsMandatory { get; set; }

        [JsonPropertyName("isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("isInternal")]
        public bool IsInternal { get; set; }
    }
}

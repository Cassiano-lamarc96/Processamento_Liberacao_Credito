using System.Text.Json.Serialization;

namespace Processamento_Liberacao_Credito.Application.Models.ResponsesModel
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; } = false;

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; } = string.Empty;

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("dataResult")]
        public T? DataResult { get; set; }
    }
}

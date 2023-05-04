using System.Text.Json.Serialization;

namespace Processamento_Liberacao_Credito.Application.Models.ResponsesModel
{
    public class ReleaseCreditCalculateResponse
    {
        [JsonPropertyName("approved")]
        public bool Approved { get; set; }

        // (CET) Custo efetivo total
        [JsonPropertyName("TEC")]
        public decimal? TotalEffectiveCost { get; set; }

        [JsonPropertyName("interestAmount")]
        public decimal InterestAmount { get; set; }
    }
}

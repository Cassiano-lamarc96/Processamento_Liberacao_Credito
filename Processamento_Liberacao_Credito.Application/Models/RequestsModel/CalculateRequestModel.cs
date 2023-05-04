using System.Text.Json.Serialization;

namespace Processamento_Liberacao_Credito.Application.Models.RequestsModel
{
    public class CalculateRequestModel
    {
        [JsonPropertyName("creditType")]
        public CreditType? CreditType { get; set; }

        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("installmentQuantity")]
        public int? InstallmentQuantity { get; set; }

        [JsonPropertyName("firstDueDate")]
        public DateTime? FirstDueDate { get; set; }
    }

    public enum CreditType
    {
        Direto,
        Consignado,
        PJ,
        PF,
        Imobiliario
    }
}

using Processamento_Liberacao_Credito.Application.Interfaces;
using Processamento_Liberacao_Credito.Application.Models.RequestsModel;
using Processamento_Liberacao_Credito.Application.Models.ResponsesModel;
using System.Drawing;

namespace Processamento_Liberacao_Credito.Application.Services
{
    public class CreditReleaseCalculationUseCase : ICreditReleaseCalculationUseCase
    {
        private readonly decimal _maxAmount;
        private readonly decimal _minAmountCreditForPJ;
        private readonly int _minDueDate;
        private readonly int _maxDueDate;

        public CreditReleaseCalculationUseCase()
        {
            _maxAmount = 1000000;
            _minAmountCreditForPJ = 15000;
            _minDueDate = 15;
            _maxDueDate = 40;
        }

        public async Task<BaseResponse<ReleaseCreditCalculateResponse>> Handler(CalculateRequestModel calculateRequestModel)
        {
            try
            {
                Validate(calculateRequestModel);

                decimal amount = calculateRequestModel.Amount ?? 0;
                int quantity = calculateRequestModel.InstallmentQuantity ?? 0;
                CreditType creditType = calculateRequestModel.CreditType ?? CreditType.Direto;

                Dictionary<CreditType, decimal> interestRates = new Dictionary<CreditType, decimal>
                {
                    { CreditType.Direto, 2 },
                    { CreditType.Consignado, 1 },
                    { CreditType.PJ, 5 },
                    { CreditType.PF, 3 },
                    { CreditType.Imobiliario, 9 }
                };

                decimal interestRate = 0;
                if (interestRates.TryGetValue(creditType, out decimal rate))
                    interestRate = rate;

                var totalEffectiveCost = amount + (amount * ((quantity * interestRate) / 100));
                var interestAmount = totalEffectiveCost - amount;

                return new BaseResponse<ReleaseCreditCalculateResponse>
                {
                    Error = false,
                    DataResult = new ReleaseCreditCalculateResponse()
                    {
                        Approved = true,
                        InterestAmount = interestAmount,
                        TotalEffectiveCost = totalEffectiveCost,
                    }
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<ReleaseCreditCalculateResponse>()
                {
                    Error = true,
                    ErrorMessage = e.Message,
                    DataResult = new ReleaseCreditCalculateResponse()
                    {
                        Approved = false
                    }
                };
            }
        }

        private void Validate(CalculateRequestModel calculateRequestModel)
        {
            if (!calculateRequestModel.Amount.HasValue)
                throw new Exception("Valor do crédito é obrigatório");

            if (!calculateRequestModel.InstallmentQuantity.HasValue)
                throw new Exception("Quantidade de parcelas é obrigatório");

            if (!calculateRequestModel.CreditType.HasValue)
                throw new Exception("Tipo de crédito é obrigatório (Ex.: Crédito Direto, Consignado, Pessoa Jurídica, Pessoa Fisíca, Imobiliário");

            if (!Enum.IsDefined(typeof(CreditType), calculateRequestModel.CreditType.Value))
                throw new Exception("Escolha um tipo de crédito corretamente");

            if (!calculateRequestModel.FirstDueDate.HasValue)
                throw new Exception("Data do primeiro vencimento é obrigatório");

            if (calculateRequestModel.Amount.Value > _maxAmount)
                throw new Exception($"Valor do crédito não pode ser maior que {_maxAmount.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}");

            if (calculateRequestModel.InstallmentQuantity.Value < 5 || calculateRequestModel.InstallmentQuantity.Value > 72)
                throw new Exception("Quantidade de parcelas deve ser entre 5 e 72x");

            if (calculateRequestModel.CreditType.Value == CreditType.PJ && calculateRequestModel.Amount < _minAmountCreditForPJ)
                throw new Exception($"Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de {_minAmountCreditForPJ.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}");

            if (calculateRequestModel.FirstDueDate.Value < DateTime.UtcNow.AddDays(-3).Date)
                throw new Exception("Data do primeiro vencimento deve ser maior do que hoje");

            var firstDueDateDiff = (calculateRequestModel.FirstDueDate.Value.Date - DateTime.UtcNow.AddDays(-3).Date).Days;
            if (firstDueDateDiff < _minDueDate || firstDueDateDiff > _maxDueDate)
                throw new Exception($"A data do primeiro vencimento sempre será no mínimo {_minDueDate} dias e no máximo {_maxDueDate} dias a partir da data atual.");
        }
    }
}

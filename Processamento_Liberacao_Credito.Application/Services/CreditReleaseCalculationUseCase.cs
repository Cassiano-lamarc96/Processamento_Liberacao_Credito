using Processamento_Liberacao_Credito.Application.Interfaces;
using Processamento_Liberacao_Credito.Application.Models.RequestsModel;
using Processamento_Liberacao_Credito.Application.Models.ResponsesModel;

namespace Processamento_Liberacao_Credito.Application.Services
{
    public class CreditReleaseCalculationUseCase : ICreditReleaseCalculationUseCase
    {
        public async Task<BaseResponse<ReleaseCreditCalculateResponse>> Handler(CalculateRequestModel calculateRequestModel)
        {
            return await Task.FromResult(new BaseResponse<ReleaseCreditCalculateResponse> { });
        }
    }
}

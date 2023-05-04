using Processamento_Liberacao_Credito.Application.Models.RequestsModel;
using Processamento_Liberacao_Credito.Application.Models.ResponsesModel;

namespace Processamento_Liberacao_Credito.Application.Interfaces
{
    public interface ICreditReleaseCalculationUseCase
    {
        Task<BaseResponse<ReleaseCreditCalculateResponse>> Handler(CalculateRequestModel calculateRequestModel);
    }
}

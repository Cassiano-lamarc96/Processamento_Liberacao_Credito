using Microsoft.AspNetCore.Mvc;
using Processamento_Liberacao_Credito.Application.Interfaces;
using Processamento_Liberacao_Credito.Application.Models.RequestsModel;
using Processamento_Liberacao_Credito.Application.Models.ResponsesModel;

namespace Processamento_Liberacao_Credito.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessingController : Controller
    {
        public ProcessingController(ICreditReleaseCalculationUseCase creditReleaseCalculationUseCase)
        {
            _creditReleaseCalculationUseCase = creditReleaseCalculationUseCase;
        }

        private readonly ICreditReleaseCalculationUseCase _creditReleaseCalculationUseCase;

        [HttpPost("calculate")]
        public async Task<BaseResponse<ReleaseCreditCalculateResponse>> Calculate([FromBody] CalculateRequestModel requestModel)
        {
            return await _creditReleaseCalculationUseCase.Handler(requestModel);
        }
    }
}

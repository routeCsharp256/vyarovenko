using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchandiseService _merchService;

        public MerchController(IMerchandiseService stockService)
        {
            _merchService = stockService;
        }
        /// <summary>
        /// Запросить мерч
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="token">токен</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMerch")]
        [ProducesResponseType(typeof(GetMerchResponseModel),200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<GetMerchResponseModel>> GetMerch([FromQuery] long id, CancellationToken token)
        {
            var merchItem = await _merchService.GetMerch(token);
            if(merchItem == null)
            {
                return NotFound();
            }
            GetMerchResponseModel response = new GetMerchResponseModel
            {
                Name = merchItem.Name
            };
            return Ok(response);
        }
        /// <summary>
        /// Получить информацию о выдаче мерча
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="token">токен</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMerchIsIssued")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> GetMerchIsIssued([FromQuery] long id, CancellationToken token)
        {
            //throw new Exception("my Exception");
            var merchIsIssued = await _merchService.GetMerchIsIssued(token);
            return Ok(merchIsIssued);
        }
    }
}

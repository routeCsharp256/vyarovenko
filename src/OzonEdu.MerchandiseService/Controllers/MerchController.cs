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
        /// Выдача мерча по запросу:
        /// Через REST API приходит запрос на выдачу мерча сотруднику
        /// Проверяется что такой мерч еще не выдавался сотруднику
        /// Проверяется наличие данного мерча на складе через запрос к stock-api
        /// Если все проверки прошли - зарезервировать мерч в stock-api
        /// Отметить у себя в БД, что сотруднику выдан мерч
        /// Если мерча нет в наличии - необходимо запомнить, что такой сотрудник запрашивал такой мерч, и при появлении его на остатках - отправить уведомление
        /// </summary>
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
        /// Информация о выданном мерче
        /// Реализовать REST-api метод, который будет возвращать по сотруднику информацию - какой мерч ему
        /// выдавался
        /// </summary>
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

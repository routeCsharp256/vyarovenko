using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Infrastructure.Mediator.Commands.GetMerch;
using OzonEdu.MerchandiseService.Maper;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [Produces("application/json")]
        public async Task<IActionResult> OrderMerch([FromBody] OrderMerchModel model, CancellationToken token)
        {
            if (model.MerchItems.Count <= 0)
            {
                return NotFound();
            }

            var orderMerchCommand = OrderMerchModelToOrderMerchCommandMaper.MapOrderMerchModel(model);

            //await _mediator.Send(orderMerchCommand, token);
            return Ok();
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<MerchModel>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<MerchModel>>> GetMerch([FromQuery] string email, CancellationToken token)
        {
            //var getMerchCommand = new GetMerchCommand { Email = email };
            //var merchItems = await _mediator.Send(getMerchCommand, token);

            var result = new List<MerchModel>()
            {
                // Testing data
                new MerchModel() {ItemType = "TShort", Quantity = 12, Tag = "test1"},
                new MerchModel() {ItemType = "TShort", Quantity = 12, Tag = "test1"}
            };
            //merchItems?.ForEach((i) =>
            //{
            //    result.Add(new MerchModel
            //    {
            //        ItemType = i.ItemType.Value.Name,
            //        Quantity = i.Quantity.Value,
            //        Tag = i.Tag.Value
            //    });
            //});
            return Ok(result);
        }
    }
}

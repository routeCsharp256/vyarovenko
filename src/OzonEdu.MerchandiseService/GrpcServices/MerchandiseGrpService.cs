using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Services.Interfaces;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseGrpService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseService _merchService;
        /// <summary>
        /// Выдача мерча по запросу:
        /// Через REST API приходит запрос на выдачу мерча сотруднику
        /// Проверяется что такой мерч еще не выдавался сотруднику
        /// Проверяется наличие данного мерча на складе через запрос к stock-api
        /// Если все проверки прошли - зарезервировать мерч в stock-api
        /// Отметить у себя в БД, что сотруднику выдан мерч
        /// Если мерча нет в наличии - необходимо запомнить, что такой сотрудник запрашивал такой мерч, и при появлении его на остатках - отправить уведомление
        /// </summary>
        public MerchandiseGrpService(IMerchandiseService merchandiseService)
        {
            _merchService = merchandiseService;
        }
        
        public override async Task<GetMerchItemsResponse> GetMerch(GetMerchItemsRequest item, ServerCallContext context)
        {
            var merch = await _merchService.GetMerch(context.CancellationToken);
            return new GetMerchItemsResponse { Name = merch.Name };
        }
        /// <summary>
        /// Информация о выданном мерче
        /// Реализовать REST-api метод, который будет возвращать по сотруднику информацию - какой мерч ему
        /// выдавался
        /// </summary>
        public override async Task<GetMerchIsIssuedItemsResponse> GetMerchIsIssued(GetMerchIsIssuedItemsRequest item, ServerCallContext context)
        {
            var merch = await _merchService.GetMerchIsIssued(context.CancellationToken);
            return new GetMerchIsIssuedItemsResponse { IsIssued = merch };
        }
    }
}

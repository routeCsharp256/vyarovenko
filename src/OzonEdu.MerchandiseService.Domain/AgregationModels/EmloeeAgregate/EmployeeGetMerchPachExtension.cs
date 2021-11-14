using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchPackAgregate;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate
{
    public static class EmployeeGetMerchPachExtension
    {
        /// <summary>
        /// Заказать Welcome Pack
        /// </summary>
        public static void OrderWelcomePack(this Employee employee, bool flag)
        {
            employee.OrderMerch(flag, MerchPack.GetWelcomePack(employee.Size).GetItems());
        }

        /// <summary>
        /// Заказать Starter Pack
        /// </summary>
        public static void OrderStarterPack(this Employee employee, bool flag)
        {
            employee.OrderMerch(flag, MerchPack.GetStarterPack(employee.Size).GetItems());
        }

        /// <summary>
        /// Заказать ConferenceListener Pack
        /// </summary>
        public static void OrderConferenceListenerPack(this Employee employee, bool flag)
        {
            employee.OrderMerch(flag, MerchPack.GetConferenceListenerPack().GetItems());
        }

        /// <summary>
        /// Заказать Conference SpeakerPack
        /// </summary>
        public static void OrderConferenceSpeakerPack(this Employee employee, bool flag)
        {
            employee.OrderMerch(flag, MerchPack.GetConferenceSpeakerPack(employee.Size).GetItems());
        }

        /// <summary>
        /// Заказать Veteran Pack
        /// </summary>
        public static void OrderVeteranPack(this Employee employee, bool flag)
        {
            employee.OrderMerch(flag, MerchPack.GetVeteranPack(employee.Size).GetItems());
        }
    }
}

using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.Models;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchPackAgregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : Entity, IAggregateRoot
    {
        /// <summary>
        /// Email
        /// </summary>
        public MailAddress Email { get; private set; }

        /// <summary>
        /// Размер одежды
        /// </summary>
        public ClouthingSize Size { get; private set; }

        /// <summary>
        /// Полученный мерч
        /// </summary>
        List<MerchItem> ReceivedMerchItems { get; set; }

        /// <summary>
        /// Не полученный мерч
        /// </summary>
        List<MerchItem> OrderMerchItems { get; set; }

        public Employee(MailAddress email, ClouthingSize size)
        {
            if (email is null) throw new ArgumentNullException("Email Items is null");
            if ((size is null) ||
                size.Equals(ClouthingSize.NULL)) throw new ArgumentNullException("Size is null");
            Email = email;
            Size = size;
            ReceivedMerchItems = new List<MerchItem>();
            OrderMerchItems = new List<MerchItem>();
        }

        /// <summary>
        /// Получить список полученного мерча
        /// </summary>
        /// <returns></returns>
        public List<MerchItem> GetReceivedMerchItems() => ReceivedMerchItems;

        /// <summary>
        /// Получить список не полученного мерча
        /// </summary>
        /// <returns></returns>
        public List<MerchItem> GetOrderMerchItems() => OrderMerchItems;

        /// <summary>
        /// Заказать мерч
        /// </summary>
        /// <param name="flag">Удалось ли получить мерч</param>
        /// <param name="items">Сам мерч</param>
        public void OrderMerch(bool flag, params MerchItem[] items)
        {
            if (flag)
            {
                ReceivedMerchItems.AddRange(items);
                SendEmail("Мерч заказан, подойдите к менеджеру для получения");
            }
            else
            {
                OrderMerchItems.AddRange(items);
                SendEmail("Мерч не удалось заказать, ожидаем поставок");
            }
        }

        /// <summary>
        /// Заказать мерч
        /// </summary>
        /// <param name="flag">Удалось ли получить мерч</param>
        /// <param name="items">Сам мерч</param>
        public void OrderMerch(bool flag, IEnumerable<MerchItem> items)
        {
            if (flag)
            {
                ReceivedMerchItems.AddRange(items);
                SendEmail("Мерч заказан, подойдите к менеджеру для получения");
            }
            else
            {
                OrderMerchItems.AddRange(items);
                SendEmail("Мерч не удалось заказать, ожидаем поставок");
            }
        }

        /// <summary>
        /// Метод заказа мерча во время прихода поставок
        /// </summary>
        public void ReOrderMerch()
        {
            ReceivedMerchItems.AddRange(OrderMerchItems);
            OrderMerchItems.Clear();
            SendEmail("Мерч заказан, подойдите к менеджеру для получения");
        }

        /// <summary>
        /// Отпарвка email уведомленния сотруднику
        /// </summary>
        /// <param name="text"></param>
        void SendEmail(string text)
        {
        }

        /// <summary>
        /// Заказать Welcome Pack
        /// </summary>
        public void OrderWelcomePack(bool flag)
        {
            OrderMerch(flag, MerchPack.GetWelcomePack(Size).GetItems());
        }

        /// <summary>
        /// Заказать Starter Pack
        /// </summary>
        public void OrderStarterPack(bool flag)
        {
            OrderMerch(flag, MerchPack.GetStarterPack(Size).GetItems());
        }

        /// <summary>
        /// Заказать ConferenceListener Pack
        /// </summary>
        public void OrderConferenceListenerPack(bool flag)
        {
            OrderMerch(flag, MerchPack.GetConferenceListenerPack().GetItems());
        }

        /// <summary>
        /// Заказать Conference SpeakerPack
        /// </summary>
        public void OrderConferenceSpeakerPack(bool flag)
        {
            OrderMerch(flag, MerchPack.GetConferenceSpeakerPack(Size).GetItems());
        }

        /// <summary>
        /// Заказать Veteran Pack
        /// </summary>
        public void OrderVeteranPack(bool flag)
        {
            OrderMerch(flag, MerchPack.GetVeteranPack(Size).GetItems());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Mail;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.Models;

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
        private List<MerchItem> ReceivedMerchItems { get; }

        /// <summary>
        /// Не полученный мерч
        /// </summary>
        private List<MerchItem> OrderMerchItems { get; }

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
        public IReadOnlyCollection<MerchItem> GetReceivedMerchItems() => ReceivedMerchItems;

        /// <summary>
        /// Получить список не полученного мерча
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<MerchItem> GetOrderMerchItems() => OrderMerchItems;

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
    }
}

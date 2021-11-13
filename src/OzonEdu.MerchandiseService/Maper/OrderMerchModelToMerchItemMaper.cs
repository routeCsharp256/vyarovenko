using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.OrderMerch;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Maper
{
    public static class OrderMerchModelToOrderMerchCommandMaper
    {
        public static OrderMerchCommand MapOrderMerchModel(OrderMerchModel model)
        {
            ClouthingSize size = null;
            switch (model.Employee.Size)
            {
                case "XS":
                    size = ClouthingSize.XS;
                    break;
                case "S":
                    size = ClouthingSize.S;
                    break;
                case "M":
                    size = ClouthingSize.M;
                    break;
                case "L":
                    size = ClouthingSize.L;
                    break;
                case "XL":
                    size = ClouthingSize.XL;
                    break;
                case "XXL":
                    size = ClouthingSize.XXL;
                    break;
            }

            if (size is null) throw new FormatException("Size have not correct format");
            var items = new List<MerchItem>();
            model.MerchItems.ForEach((i) =>
            {
                switch (i.ItemType)
                {
                    case "TShort":
                        items.Add(MerchItem.GetTShort(size, i.Quantity, i.Tag));
                        break;
                    case "Sweatshirt":
                        items.Add(MerchItem.GetSweatshirt(size, i.Quantity, i.Tag));
                        break;
                    case "Notepad":
                        items.Add(MerchItem.GetNotepad(i.Quantity, i.Tag));
                        break;
                    case "Bag":
                        items.Add(MerchItem.GetBag(i.Quantity, i.Tag));
                        break;
                    case "Pen":
                        items.Add(MerchItem.GetPen(i.Quantity, i.Tag));
                        break;
                    case "Socks":
                        items.Add(MerchItem.GetSocks(i.Quantity, i.Tag));
                        break;
                }
            });
            if(model.Employee.Email is null) throw new FormatException("Email have not correct format");
            var Employee =
                new Domain.AgregationModels.EmloeeAgregate.Employee(new System.Net.Mail.MailAddress(model.Employee.Email),
                    size);
            return new OrderMerchCommand() {Employee = Employee, MerchItems = items};
        }
    }
}

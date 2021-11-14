using System;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    public partial class MerchItem
    {
        /// <summary>
        /// Получить футболку
        /// </summary>
        /// <param name="clouthingSize">Размер</param>
        /// <param name="quantity">Количество</param>
        /// <param name="tag">Тэг</param>
        /// <returns></returns>
        public static MerchItem GetTShort(ClouthingSize clouthingSize, int quantity = 1, string tag = "Без тега")
        {
            if (clouthingSize is null) throw new ArgumentNullException("Size is null");
            var sku = new Sku(1);
            var name = new Name($"Футболка размера {clouthingSize.Name}");
            return new MerchItem(sku, name, new ItemType(MerchType.TShort), clouthingSize, new Quantity(quantity),
                new Tag(tag));
        }

        /// <summary>
        /// Получить толстовку
        /// </summary>
        /// <param name="clouthingSize">Размер</param>
        /// <param name="quantity">Количество</param>
        /// <param name="tag">Тэг</param>
        /// <returns></returns>
        public static MerchItem GetSweatshirt(ClouthingSize clouthingSize, int quantity = 1, string tag = "Без тега")
        {
            if (clouthingSize is null) throw new ArgumentNullException("Size is null");
            var sku = new Sku(2);
            var name = new Name($"Толстовка размера {clouthingSize.Name}");
            return new MerchItem(sku, name, new ItemType(MerchType.Sweatshirt), clouthingSize, new Quantity(quantity),
                new Tag(tag));
        }

        /// <summary>
        /// Получить рюкзак
        /// </summary>
        /// <param name="quantity">Количество</param>
        /// <param name="tag">Тэг</param>
        /// <returns></returns>
        public static MerchItem GetBag(int quantity = 1, string tag = "Без тега")
        {
            var sku = new Sku(3);
            var name = new Name($"Рюкзак");
            return new MerchItem(sku, name, new ItemType(MerchType.Bag), new Quantity(quantity), new Tag(tag));
        }

        public static MerchItem GetNotepad(int quantity = 1, string tag = "Без тега")
        {
            var sku = new Sku(4);
            var name = new Name($"Блокнот");
            return new MerchItem(sku, name, new ItemType(MerchType.Notepad), new Quantity(quantity), new Tag(tag));
        }

        public static MerchItem GetPen(int quantity = 1, string tag = "Без тега")
        {
            var sku = new Sku(5);
            var name = new Name($"Ручка");
            return new MerchItem(sku, name, new ItemType(MerchType.Pen), new Quantity(quantity), new Tag(tag));
        }

        public static MerchItem GetSocks(int quantity = 1, string tag = "Без тега")
        {
            var sku = new Sku(6);
            var name = new Name($"Носки");
            return new MerchItem(sku, name, new ItemType(MerchType.Socks), new Quantity(quantity), new Tag(tag));
        }
    }
}

using System;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Мерч
    /// </summary>
    public partial class MerchItem : Entity, IAggregateRoot
    {
        protected MerchItem(Sku sku, Name name, ItemType itemType, ClouthingSize clouthingSize, Quantity quantity,
            Tag tag)
        {
            if (itemType is null) throw new ArgumentNullException("ItemType is null");
            if (clouthingSize is null) throw new ArgumentNullException("ClouthingSize is null");
            ClouthingSize = ClouthingSizeValidation(itemType, clouthingSize);
            Sku = sku;
            Name = name;
            ItemType = itemType;
            Quantity = quantity;
            Tag = tag;
        }

        protected MerchItem(Sku sku, Name name, ItemType itemType, ClouthingSize clouthingSize, Quantity quantity)
            : this(sku, name, itemType, clouthingSize, quantity, new NoneTag())
        {
        }

        protected MerchItem(Sku sku, Name name, ItemType itemType, ClouthingSize clouthingSize, Tag tag)
            : this(sku, name, itemType, clouthingSize, new Quantity(1), tag)
        {
        }

        protected MerchItem(Sku sku, Name name, ItemType itemType, ClouthingSize clouthingSize)
            : this(sku, name, itemType, clouthingSize, new Quantity(1))
        {
        }

        protected MerchItem(Sku sku, Name name, ItemType itemType, Quantity quantity, Tag tag)
            : this(sku, name, itemType, ClouthingSize.NULL, quantity, tag)
        {
        }

        protected MerchItem(Sku sku, Name name, ItemType itemType, Quantity quantity)
            : this(sku, name, itemType, quantity, new NoneTag())
        {
        }

        protected MerchItem(Sku sku, Name name, ItemType itemType, Tag tag)
            : this(sku, name, itemType, new Quantity(1), tag)
        {
        }

        protected MerchItem(Sku sku, Name name, ItemType itemType)
            : this(sku, name, itemType, new Quantity(1))
        {
        }

        /// <summary>
        /// Идентификатор мерча на складе
        /// </summary>
        public Sku Sku { get; private set; }

        /// <summary>
        /// Название мерча
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Вид мерча
        /// </summary>
        public ItemType ItemType { get; private set; }

        /// <summary>
        /// Размер одежды
        /// </summary>
        public ClouthingSize ClouthingSize { get; private set; }

        /// <summary>
        /// Количество мерча
        /// </summary>
        public Quantity Quantity { get; private set; }

        /// <summary>
        /// Заметка по мерчу
        /// </summary>
        public Tag Tag { get; private set; }

        private static ClouthingSize ClouthingSizeValidation(ItemType itemType, ClouthingSize size)
        {
            var type = itemType.Value;
            if ((type.Equals(MerchType.TShort) || type.Equals(MerchType.Sweatshirt)) && size.Equals(ClouthingSize.NULL))
                throw new NotSizeException("Одежа не может быть заказана без размера");
            else if (type.Equals(MerchType.TShort) || type.Equals(MerchType.Sweatshirt)) return size;
            else return ClouthingSize.NULL;
        }

        /// <summary>
        /// Изменить кол-во товаров
        /// </summary>
        public void ChangeQuantity(int quantity)
        {
            if (quantity <= 0) throw new ArgumentNullException("New quantity is negative or null!");
            Quantity = new Quantity(quantity);
        }

        /// <summary>
        /// Изменить размер
        /// </summary>
        public void ChangeSize(ClouthingSize clouthingSize)
        {
            if ((clouthingSize is null) || clouthingSize.Equals(ClouthingSize.NULL))
                throw new ArgumentNullException("Size is null");
            if ((ItemType.Value != MerchType.TShort) &&
                (ItemType.Value != MerchType.Sweatshirt))
                throw new NotValideSizeException("You cannot change suze for this Merch");
            ClouthingSize = clouthingSize;
        }

        /// <summary>
        /// Изменить тэг
        /// </summary>
        public void ChangeTag(string tag)
        {
            if (tag is null) throw new ArgumentNullException("Tag is null");
            Tag = new Tag(tag);
        }
    }

}

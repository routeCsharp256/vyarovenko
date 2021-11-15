using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using System;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class MerchItemValueObjectTests
    {
        [Fact]
        public void CreateTShort()
        {
            #region Arrive
            var size = ClouthingSize.M;
            #endregion
            #region Act
            var merchItem = MerchItem.GetTShort(size);
            #endregion
            #region Assert
            Assert.Equal(1, merchItem.Sku.Value);
            Assert.Equal($"Футболка размера {size.Name}", merchItem.Name.Value);
            Assert.Equal(MerchType.TShort, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(1, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateTShortWithNullSize()
        {
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetTShort(null));
        }
        [Fact]
        public void CreateTShortWithQuality()
        {
            #region Arrive
            var size = ClouthingSize.M;
            var quality = 5;
            #endregion
            #region Act
            var merchItem = MerchItem.GetTShort(size, quality);
            #endregion
            #region Assert
            Assert.Equal(1, merchItem.Sku.Value);
            Assert.Equal($"Футболка размера {size.Name}", merchItem.Name.Value);
            Assert.Equal(MerchType.TShort, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateTShortWithQualityAndTag()
        {
            #region Arrive
            var size = ClouthingSize.M;
            var quality = 5;
            var tag = "test";
            #endregion
            #region Act
            var merchItem = MerchItem.GetTShort(size, quality,tag);
            #endregion
            #region Assert
            Assert.Equal(1, merchItem.Sku.Value);
            Assert.Equal($"Футболка размера {size.Name}", merchItem.Name.Value);
            Assert.Equal(MerchType.TShort, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal(tag, merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateTShortWithZiroQuality()
        {
            var size = ClouthingSize.M;
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetTShort(size,0));
        }
        [Fact]
        public void CreateTShortWithNegativeQuality()
        {
            var size = ClouthingSize.M;
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetTShort(size, -10));
        }
        [Fact]
        public void CreateTShortWithNullTag()
        {
            var size = ClouthingSize.M;
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetTShort(size, 1, null));
        }

        [Fact]
        public void CreateSweatshirt()
        {
            #region Arrive
            var size = ClouthingSize.M;
            #endregion
            #region Act
            var merchItem = MerchItem.GetSweatshirt(size);
            #endregion
            #region Assert
            Assert.Equal(2, merchItem.Sku.Value);
            Assert.Equal($"Толстовка размера {size.Name}", merchItem.Name.Value);
            Assert.Equal(MerchType.Sweatshirt, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(1, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateSweatshirtWithNullSize()
        {
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetSweatshirt(null));
        }
        [Fact]
        public void CreateSweatshirtWithQuality()
        {
            #region Arrive
            var size = ClouthingSize.M;
            var quality = 5;
            #endregion
            #region Act
            var merchItem = MerchItem.GetSweatshirt(size, quality);
            #endregion
            #region Assert
            Assert.Equal(2, merchItem.Sku.Value);
            Assert.Equal($"Толстовка размера {size.Name}", merchItem.Name.Value);
            Assert.Equal(MerchType.Sweatshirt, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateSweatshirtWithQualityAndTag()
        {
            #region Arrive
            var size = ClouthingSize.M;
            var quality = 5;
            var tag = "test";
            #endregion
            #region Act
            var merchItem = MerchItem.GetSweatshirt(size, quality, tag);
            #endregion
            #region Assert
            Assert.Equal(2, merchItem.Sku.Value);
            Assert.Equal($"Толстовка размера {size.Name}", merchItem.Name.Value);
            Assert.Equal(MerchType.Sweatshirt, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal(tag, merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateSweatshirtWithZiroQuality()
        {
            var size = ClouthingSize.M;
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetSweatshirt(size, 0));
        }
        [Fact]
        public void CreateSweatshirtWithNegativeQuality()
        {
            var size = ClouthingSize.M;
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetSweatshirt(size, -10));
        }
        [Fact]
        public void CreateSweatshirtWithNullTag()
        {
            var size = ClouthingSize.M;
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetSweatshirt(size, 1, null));
        }

        [Fact]
        public void CreateNotepad()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            #endregion
            #region Act
            var merchItem = MerchItem.GetNotepad();
            #endregion
            #region Assert
            Assert.Equal(4, merchItem.Sku.Value);
            Assert.Equal("Блокнот", merchItem.Name.Value);
            Assert.Equal(MerchType.Notepad, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(1, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateNotepadWithQuality()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            #endregion
            #region Act
            var merchItem = MerchItem.GetNotepad(quality);
            #endregion
            #region Assert
            Assert.Equal(4, merchItem.Sku.Value);
            Assert.Equal("Блокнот", merchItem.Name.Value);
            Assert.Equal(MerchType.Notepad, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateNotepadWithQualityAndTag()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            var tag = "test";
            #endregion
            #region Act
            var merchItem = MerchItem.GetNotepad(quality, tag);
            #endregion
            #region Assert
            Assert.Equal(4, merchItem.Sku.Value);
            Assert.Equal("Блокнот", merchItem.Name.Value);
            Assert.Equal(MerchType.Notepad, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal(tag, merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateNotepadWithZiroQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetNotepad(0));
        }
        [Fact]
        public void CreateNotepadWithNegativeQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetNotepad(-10));
        }
        [Fact]
        public void CreateNotepadWithNullTag()
        {
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetNotepad(1, null));
        }
        [Fact]
        public void CreateBag()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            #endregion
            #region Act
            var merchItem = MerchItem.GetBag();
            #endregion
            #region Assert
            Assert.Equal(3, merchItem.Sku.Value);
            Assert.Equal("Рюкзак", merchItem.Name.Value);
            Assert.Equal(MerchType.Bag, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(1, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateBagWithQuality()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            #endregion
            #region Act
            var merchItem = MerchItem.GetBag(quality);
            #endregion
            #region Assert
            Assert.Equal(3, merchItem.Sku.Value);
            Assert.Equal("Рюкзак", merchItem.Name.Value);
            Assert.Equal(MerchType.Bag, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateBagWithQualityAndTag()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            var tag = "test";
            #endregion
            #region Act
            var merchItem = MerchItem.GetBag(quality, tag);
            #endregion
            #region Assert
            Assert.Equal(3, merchItem.Sku.Value);
            Assert.Equal("Рюкзак", merchItem.Name.Value);
            Assert.Equal(MerchType.Bag, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal(tag, merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateBagWithZiroQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetBag(0));
        }
        [Fact]
        public void CreateBagWithNegativeQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetBag(-10));
        }
        [Fact]
        public void CreateBagWithNullTag()
        {
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetBag(1, null));
        }
        [Fact]
        public void CreatePen()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            #endregion
            #region Act
            var merchItem = MerchItem.GetPen();
            #endregion
            #region Assert
            Assert.Equal(5, merchItem.Sku.Value);
            Assert.Equal("Ручка", merchItem.Name.Value);
            Assert.Equal(MerchType.Pen, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(1, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreatePenWithQuality()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            #endregion
            #region Act
            var merchItem = MerchItem.GetPen(quality);
            #endregion
            #region Assert
            Assert.Equal(5, merchItem.Sku.Value);
            Assert.Equal("Ручка", merchItem.Name.Value);
            Assert.Equal(MerchType.Pen, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreatePenWithQualityAndTag()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            var tag = "test";
            #endregion
            #region Act
            var merchItem = MerchItem.GetPen(quality, tag);
            #endregion
            #region Assert
            Assert.Equal(5, merchItem.Sku.Value);
            Assert.Equal("Ручка", merchItem.Name.Value);
            Assert.Equal(MerchType.Pen, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal(tag, merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreatePenWithZiroQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetPen(0));
        }
        [Fact]
        public void CreatePenWithNegativeQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetPen(-10));
        }
        [Fact]
        public void CreatePenWithNullTag()
        {
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetPen(1, null));
        }
        [Fact]
        public void CreateSocks()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            #endregion
            #region Act
            var merchItem = MerchItem.GetSocks();
            #endregion
            #region Assert
            Assert.Equal(6, merchItem.Sku.Value);
            Assert.Equal("Носки", merchItem.Name.Value);
            Assert.Equal(MerchType.Socks, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(1, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateSocksWithQuality()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            #endregion
            #region Act
            var merchItem = MerchItem.GetSocks(quality);
            #endregion
            #region Assert
            Assert.Equal(6, merchItem.Sku.Value);
            Assert.Equal("Носки", merchItem.Name.Value);
            Assert.Equal(MerchType.Socks, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal("Без тега", merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateSocksWithQualityAndTag()
        {
            #region Arrive
            var size = ClouthingSize.NULL;
            var quality = 5;
            var tag = "test";
            #endregion
            #region Act
            var merchItem = MerchItem.GetSocks(quality, tag);
            #endregion
            #region Assert
            Assert.Equal(6, merchItem.Sku.Value);
            Assert.Equal("Носки", merchItem.Name.Value);
            Assert.Equal(MerchType.Socks, merchItem.ItemType.Value);
            Assert.Equal(size, merchItem.ClouthingSize);
            Assert.Equal(quality, merchItem.Quantity.Value);
            Assert.Equal(tag, merchItem.Tag.Value);
            #endregion
        }
        [Fact]
        public void CreateSocksWithZiroQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetSocks(0));
        }
        [Fact]
        public void CreateSocksWithNegativeQuality()
        {
            Assert.Throws<NotValideQuantityExcepton>(() => MerchItem.GetSocks(-10));
        }
        [Fact]
        public void CreateSocksWithNullTag()
        {
            Assert.Throws<ArgumentNullException>(() => MerchItem.GetSocks(1, null));
        }

        [Fact]
        public void ChangeQuaontityZiro()
        {
            var item = MerchItem.GetBag(1);
            Assert.Throws<ArgumentNullException>(() => item.ChangeQuantity(0));
        }
        [Fact]
        public void ChangeQuaontityNegative()
        {
            var item = MerchItem.GetBag(1);
            Assert.Throws<ArgumentNullException>(() => item.ChangeQuantity(-20));
        }
        [Fact]
        public void ChangeQuaontity()
        {
            var item = MerchItem.GetBag(1);
            item.ChangeQuantity(5);
            Assert.Equal(5, item.Quantity.Value);
        }
        [Fact]
        public void ChangeSizeNull()
        {
            var item = MerchItem.GetBag(1);
            Assert.Throws<ArgumentNullException>(() => item.ChangeSize(null));
        }
        [Fact]
        public void ChangeSizeNullObject()
        {
            var item = MerchItem.GetBag(1);
            Assert.Throws<ArgumentNullException>(() => item.ChangeSize(ClouthingSize.NULL));
        }
        [Fact]
        public void ChangeSizeNotClothes()
        {
            var item = MerchItem.GetBag(1);
            Assert.Throws<NotValideSizeException>(() => item.ChangeSize(ClouthingSize.M));
        }
        [Fact]
        public void ChangeSizeTShort()
        {
            var item = MerchItem.GetTShort(ClouthingSize.S,1);
            item.ChangeSize(ClouthingSize.M);
            Assert.Equal(item.ClouthingSize, ClouthingSize.M);
        }
        [Fact]
        public void ChangeSizeSweatshirt()
        {
            var item = MerchItem.GetSweatshirt(ClouthingSize.S, 1);
            item.ChangeSize(ClouthingSize.M);
            Assert.Equal(item.ClouthingSize, ClouthingSize.M);
        }
        [Fact]
        public void ChangeTag()
        {
            var item = MerchItem.GetBag();
            item.ChangeTag("test");
            Assert.Equal("test", item.Tag.Value);
        }
        [Fact]
        public void ChangeTagNull()
        {
            var item = MerchItem.GetBag();
            Assert.Throws<ArgumentNullException>(() => item.ChangeTag(null));
        }
    }
}

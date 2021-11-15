using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchPackAgregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchPackTests
{
    public class MerchPackTests
    {
        [Fact]
        public void CreateMerchPackEmpty()
        {
            #region Arrive
            var pack = new MerchPack();
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(0, pack.Count);
            #endregion
        }
        [Fact]
        public void CreateMerchPackParams()
        {
            #region Arrive
            var bag = MerchItem.GetBag();
            var pen = MerchItem.GetPen();
            var pack = new MerchPack(bag,pen);
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(2,pack.Count);
            #endregion
        }
        [Fact]
        public void CreateMerchPackIEnumirable()
        {
            #region Arrive
            var items = new List<MerchItem>
            {
                MerchItem.GetBag(),
                MerchItem.GetPen()
            };
            var pack = new MerchPack(items);
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(2, pack.Count);
            #endregion
        }
        [Fact]
        public void AddItemToMerchPack()
        {
            #region Arrive
            var pack = new MerchPack();
            #endregion
            #region Act
            pack.AddMerch(MerchItem.GetPen());
            pack.AddMerch(MerchItem.GetPen());
            #endregion
            #region Assert
            Assert.Equal(2, pack.Count);
            #endregion
        }
        [Fact]
        public void AddNullItemToMerchPach()
        {
            var pack = new MerchPack();
            Assert.Throws<ArgumentNullException>(() => pack.AddMerch(null));
        }
        [Fact]
        public void GetStarterPack()
        {
            #region Arrive
            var pack = MerchPack.GetStarterPack(ClouthingSize.M);
            #endregion
            #region Act
            var items = pack.GetItems();
            #endregion
            #region Assert
            Assert.Equal(5, items.Count);
            Assert.Equal(items[0].ItemType.Value,MerchType.Notepad);
            Assert.Equal(items[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items[2].ItemType.Value, MerchType.TShort);
            Assert.Equal(items[3].ItemType.Value, MerchType.Socks);
            Assert.Equal(items[4].ItemType.Value, MerchType.Bag);
            #endregion
        }
        [Fact]
        public void GetStarterPackNullObject()
        {
            Assert.Throws<NotSizeException>(() => MerchPack.GetStarterPack(ClouthingSize.NULL));
        }
        [Fact]
        public void GetStarterPackNull()
        {
            Assert.Throws<ArgumentNullException>(() => MerchPack.GetStarterPack(null));
        }
        [Fact]
        public void GetWelcomePack()
        {
            #region Arrive
            var pack = MerchPack.GetWelcomePack(ClouthingSize.M);
            #endregion
            #region Act
            var items = pack.GetItems();
            #endregion
            #region Assert
            Assert.Equal(3, items.Count);
            Assert.Equal(items[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items[2].ItemType.Value, MerchType.TShort);
            #endregion
        }
        [Fact]
        public void GetWelcomePackNullObject()
        {
            Assert.Throws<NotSizeException>(() => MerchPack.GetWelcomePack(ClouthingSize.NULL));
        }
        [Fact]
        public void GetWelcomePackNull()
        {
            Assert.Throws<ArgumentNullException>(() => MerchPack.GetWelcomePack(null));
        }
        [Fact]
        public void GetConferenceSpeakerPack()
        {
            #region Arrive
            var pack = MerchPack.GetConferenceSpeakerPack(ClouthingSize.M);
            #endregion
            #region Act
            var items = pack.GetItems();
            #endregion
            #region Assert
            Assert.Equal(4, items.Count);
            Assert.Equal(items[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items[2].ItemType.Value, MerchType.TShort);
            Assert.Equal(items[3].ItemType.Value, MerchType.Sweatshirt);
            #endregion
        }
        [Fact]
        public void GetConferenceSpeakerPackNullObject()
        {
            Assert.Throws<NotSizeException>(() => MerchPack.GetConferenceSpeakerPack(ClouthingSize.NULL));
        }
        [Fact]
        public void GetConferenceSpeakerPackNull()
        {
            Assert.Throws<ArgumentNullException>(() => MerchPack.GetConferenceSpeakerPack(null));
        }
        [Fact]
        public void GetVeteranPack()
        {
            #region Arrive
            var pack = MerchPack.GetVeteranPack(ClouthingSize.M);
            #endregion
            #region Act
            var items = pack.GetItems();
            #endregion
            #region Assert
            Assert.Equal(6, items.Count);
            Assert.Equal(items[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items[2].ItemType.Value, MerchType.TShort);
            Assert.Equal(items[3].ItemType.Value, MerchType.Sweatshirt);
            Assert.Equal(items[4].ItemType.Value, MerchType.Socks);
            Assert.Equal(items[5].ItemType.Value, MerchType.Bag);
            #endregion
        }
        [Fact]
        public void GetVeteranPackNullObject()
        {
            Assert.Throws<NotSizeException>(() => MerchPack.GetVeteranPack(ClouthingSize.NULL));
        }
        [Fact]
        public void GetVeteranPackNull()
        {
            Assert.Throws<ArgumentNullException>(() => MerchPack.GetVeteranPack(null));
        }
        [Fact]
        public void GetConferenceListenerPack()
        {
            #region Arrive
            var pack = MerchPack.GetConferenceListenerPack();
            #endregion
            #region Act
            var items = pack.GetItems();
            #endregion
            #region Assert
            Assert.Equal(2, items.Count);
            Assert.Equal(items[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items[1].ItemType.Value, MerchType.Pen);
            #endregion
        }
    }
}

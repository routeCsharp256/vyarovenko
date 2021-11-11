using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using Xunit;
using System;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class MerchTypeValueObjectTests
    {
        [Fact]
        public void CreateMerchTypeNull()
        {
            #region Arrive
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new MerchType(0,null));
            #endregion
        }
        [Fact]
        public void CreateMerchType()
        {
            #region Arrive
            int id = 0;
            string name = "text";
            #endregion
            #region Act
            var merchType = new MerchType(id,name);
            #endregion
            #region Assert
            Assert.Equal(name, merchType.Name);
            Assert.Equal(id, merchType.Id);
            #endregion
        }
    }
}

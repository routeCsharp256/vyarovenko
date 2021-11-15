using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using System;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class ClouthingSizeValueObjectTests
    {
        [Fact]
        public void CreateMerchTypeNull()
        {
            #region Arrive
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new MerchType(0, null));
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
            var сlouthingSize = new ClouthingSize(id, name);
            #endregion
            #region Assert
            Assert.Equal(name, сlouthingSize.Name);
            Assert.Equal(id, сlouthingSize.Id);
            #endregion
        }
    }
}

using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using System;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class SkuValueObjectTests
    {
        [Fact]
        public void CreateTag()
        {
            #region Arrive
            long skuNumber = 100;
            #endregion
            #region Act
            var sku = new Sku(skuNumber);
            #endregion
            #region Assert
            Assert.Equal(skuNumber, sku.Value);
            #endregion
        }
    }
}

using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class QuantityValueObjectTests
    {
        [Fact]
        public void AddQuantity()
        {
            #region Arrive
            var quantity = new Quantity(10);
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(10, quantity.Value);
            #endregion
        }
        [Fact]
        public void AddNegativeQuantity()
        {
            #region Arrive
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<NotValideQuantityExcepton>(() => new Quantity(-20));
            #endregion
        }
        [Fact]
        public void AddZiroQuantity()
        {
            #region Arrive
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<NotValideQuantityExcepton>(() => new Quantity(0));
            #endregion
        }
    }
}

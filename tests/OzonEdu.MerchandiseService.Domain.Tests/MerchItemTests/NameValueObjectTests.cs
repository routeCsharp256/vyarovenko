using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using Xunit;
using System;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class NameValueObjectTests
    {
        [Fact]
        public void CreateNameNull()
        {
            #region Arrive
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new Name(null));
            #endregion
        }
        [Fact]
        public void CreateName()
        {
            #region Arrive
            string text = "text";
            #endregion
            #region Act
            var name = new Name(text);
            #endregion
            #region Assert
            Assert.Equal(text, name.Value);
            #endregion
        }
    }
}

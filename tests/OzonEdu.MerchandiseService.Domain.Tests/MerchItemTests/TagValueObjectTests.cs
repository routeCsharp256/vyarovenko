using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using Xunit;
using System;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class TagValueObjectTests
    {
        [Fact]
        public void CreateTagNull()
        {
            #region Arrive
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new Tag(null));
            #endregion
        }
        [Fact]
        public void CreateTag()
        {
            #region Arrive
            string text = "text";
            #endregion
            #region Act
            var tag = new Tag(text);
            #endregion
            #region Assert
            Assert.Equal(text, tag.Value);
            #endregion
        }
    }
}

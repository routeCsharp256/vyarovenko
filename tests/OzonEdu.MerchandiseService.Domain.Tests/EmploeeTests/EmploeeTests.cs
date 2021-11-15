using OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeTests
{
    public class EmployeeTests
    {
        [Fact]
        public void CreateEmployeeNullEmail()
        {
            #region Arrive
            string email = "test@mail.ru";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new Employee(null,ClouthingSize.M));
            #endregion
        }
        [Fact]
        public void CreateEmployeeNullEmailArgs()
        {
            #region Arrive
            string email = "test@mail.ru";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new Employee(new MailAddress(null), ClouthingSize.M));
            #endregion
        }
        [Fact]
        public void CreateEmployeeNotValideEmail()
        {
            #region Arrive
            string email = "dfgsdfgsd";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<FormatException>(() => new Employee(new MailAddress(email), ClouthingSize.M));
            #endregion
        }
        [Fact]
        public void CreateEmployeeNotValideEmailV2()
        {
            #region Arrive
            string email = "dfgsdfgsddmail.ru";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<FormatException>(() => new Employee(new MailAddress(email), ClouthingSize.M));
            #endregion
        }
        [Fact]
        public void CreateEmployeeNotValideEmailV3()
        {
            #region Arrive
            string email = "@dfgsdfgsddmail";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<FormatException>(() => new Employee(new MailAddress(email), ClouthingSize.M));
            #endregion
        }
        [Fact]
        public void CreateEmployeeNotValideEmailV4()
        {
            #region Arrive
            string email = "dfgsdfgsddmail@";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<FormatException>(() => new Employee(new MailAddress(email), ClouthingSize.M));
            #endregion
        }
        [Fact]
        public void CreateEmployeeNullSize()
        {
            #region Arrive
            string email = "test@mail.ru";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new Employee(new MailAddress(email), null));
            #endregion
        }
        [Fact]
        public void CreateEmployeeNullObjectSuze()
        {
            #region Arrive
            string email = "test@mail.ru";
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Throws<ArgumentNullException>(() => new Employee(new MailAddress(email), ClouthingSize.NULL));
            #endregion
        }
        [Fact]
        public void CreateEmployee()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(email, Employee.Email.Address);
            Assert.Equal(ClouthingSize.M, Employee.Size);
            #endregion
        }
        [Fact]
        public void OrderMerchTrue()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderMerch(true, MerchItem.GetBag(),MerchItem.GetNotepad());
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Empty(Employee.GetOrderMerchItems());
            Assert.Equal(2, Employee.GetReceivedMerchItems().Count);
            #endregion
        }
        [Fact]
        public void OrderMerchFalse()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderMerch(false, MerchItem.GetBag(), MerchItem.GetNotepad());
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Empty(Employee.GetReceivedMerchItems());
            Assert.Equal(2, Employee.GetOrderMerchItems().Count);
            #endregion
        }
        [Fact]
        public void ReOrderMerch()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderMerch(false, MerchItem.GetBag(), MerchItem.GetNotepad());
            Employee.ReOrderMerch();
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Empty(Employee.GetOrderMerchItems());
            Assert.Equal(2, Employee.GetReceivedMerchItems().Count);
            #endregion
        }

        [Fact]
        public void OrderWelcomePack()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderWelcomePack(true);
            var items = Employee.GetReceivedMerchItems();
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(3, items.Count);
            Assert.Equal(items.ToList()[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items.ToList()[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items.ToList()[2].ItemType.Value, MerchType.TShort);
            #endregion
        }
        [Fact]
        public void OrderStarterPack()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderStarterPack(true);
            var items = Employee.GetReceivedMerchItems();
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(5, items.Count);
            Assert.Equal(items.ToList()[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items.ToList()[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items.ToList()[2].ItemType.Value, MerchType.TShort);
            Assert.Equal(items.ToList()[3].ItemType.Value, MerchType.Socks);
            Assert.Equal(items.ToList()[4].ItemType.Value, MerchType.Bag);
            #endregion
        }
        [Fact]
        public void OrderConferenceListenerPack()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderConferenceListenerPack(true);
            var items = Employee.GetReceivedMerchItems();
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(2, items.Count);
            Assert.Equal(items.ToList()[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items.ToList()[1].ItemType.Value, MerchType.Pen);
            #endregion
        }
        [Fact]
        public void OrderConferenceSpeakerPack()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderConferenceSpeakerPack(true);
            var items = Employee.GetReceivedMerchItems();
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(4, items.Count);
            Assert.Equal(items.ToList()[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items.ToList()[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items.ToList()[2].ItemType.Value, MerchType.TShort);
            Assert.Equal(items.ToList()[3].ItemType.Value, MerchType.Sweatshirt);
            #endregion
        }
        [Fact]
        public void OrderVeteranPack()
        {
            #region Arrive
            var email = "test@mail.ru";
            var Employee = new Employee(new MailAddress(email), ClouthingSize.M);
            Employee.OrderVeteranPack(true);
            var items = Employee.GetReceivedMerchItems();
            #endregion
            #region Act
            #endregion
            #region Assert
            Assert.Equal(6, items.Count);
            Assert.Equal(items.ToList()[0].ItemType.Value, MerchType.Notepad);
            Assert.Equal(items.ToList()[1].ItemType.Value, MerchType.Pen);
            Assert.Equal(items.ToList()[2].ItemType.Value, MerchType.TShort);
            Assert.Equal(items.ToList()[3].ItemType.Value, MerchType.Sweatshirt);
            Assert.Equal(items.ToList()[4].ItemType.Value, MerchType.Socks);
            Assert.Equal(items.ToList()[5].ItemType.Value, MerchType.Bag);
            #endregion
        }
    }
}

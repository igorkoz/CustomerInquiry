using CustomerInquiry.Adapters;
using CustomerInquiry.Controllers;
using CustomerInquiry.Models;
using CustomerInquiryBusiness.Validators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CustomerInquiry.Tests
{
    [TestFixture]
    internal class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_CustomerIDandEmailIsNull_BadRequest()
        {
            // Arrange
            var context = this.CreateMocksAndControllerUnderTest();

            // Act
            IHttpActionResult result = context.ControllerUnderTest.GetCustomer();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result, "customerID and / or email should not be NULL");
        }

        [Test]
        public void GetCustomer_InvalidCustomerID_BadRequest()
        {
            // Arrange
            var context = this.CreateMocksAndControllerUnderTest();

            // Act
            IHttpActionResult result = context.ControllerUnderTest.GetCustomer(-1);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result, "Invalid customerID");
        }

        [Test]
        public void GetCustomer_InvalidEMail_BadRequest()
        {
            // Arrange
            var context = this.CreateMocksAndControllerUnderTest();

            // Act
            IHttpActionResult result = context.ControllerUnderTest.GetCustomer(1, "test");

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result, "Invalid email");
        }

        [Test]
        public void GetCustomer_ValidParameters_NotFound()
        {
            // Arrange
            var context = this.CreateMocksAndControllerUnderTest();
            context.CustomerAdapterMock.Setup(a => a.GetCustomer(It.IsAny<int>(), It.IsAny<string>())).Returns((Customer)null);
            context.Validator.Setup(v => v.ValidateEMail(It.IsAny<string>())).Returns(true);

            // Act
            IHttpActionResult result = context.ControllerUnderTest.GetCustomer(1, "test@google.com");

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void GetCustomer_ValidParameters_RecordFound()
        {
            // Arrange
            var customer = new Customer()
            {
                Name = "Peter Jones",
                Email = "PeterJones@google.com",
                MobileNo = "+380551234577",
                RecentTransactions = new List<Transaction>
                    {
                        new Transaction() { Amount = 100.01m, CurrencyCode = "USD", TransactionDateTime = "17/05/2001 23:00", Status = "Canceled" }
                    }
            };
            var context = this.CreateMocksAndControllerUnderTest();
            context.CustomerAdapterMock.Setup(a => a.GetCustomer(It.IsAny<int>(), It.IsAny<string>())).Returns(customer);
            context.Validator.Setup(v => v.ValidateEMail(It.IsAny<string>())).Returns(true);

            // Act
            var result = context.ControllerUnderTest.GetCustomer(1) as OkNegotiatedContentResult<Customer>;

            // Assert
            Assert.NotNull(result);
            Assert.IsNotNull(result.Content);
            StringAssert.Contains(customer.Name, result.Content.Name);
            StringAssert.Contains(customer.Email, result.Content.Email);
            StringAssert.Contains(customer.MobileNo, result.Content.MobileNo);
            
            var expectedTransaction = result.Content.RecentTransactions;
            var actualTransaction = customer.RecentTransactions;
            Assert.AreEqual(actualTransaction.Count, expectedTransaction.Count);
            Assert.AreEqual(actualTransaction[0].Amount, expectedTransaction[0].Amount);
            StringAssert.Contains(actualTransaction[0].CurrencyCode, expectedTransaction[0].CurrencyCode);
            StringAssert.Contains(actualTransaction[0].Status, expectedTransaction[0].Status);
            StringAssert.Contains(actualTransaction[0].TransactionDateTime, expectedTransaction[0].TransactionDateTime);
        }


        private class TestContext
        {
            public Mock<ICustomerAdapter> CustomerAdapterMock { get; set; }

            public Mock<IEMailValidator> Validator { get; set; }

            public CustomerController ControllerUnderTest { get; set; }
        }

        private TestContext CreateMocksAndControllerUnderTest()
        {
            var context = new TestContext
            {
                CustomerAdapterMock = new Mock<ICustomerAdapter>(),
                Validator = new Mock<IEMailValidator>()
            };

            context.ControllerUnderTest = new CustomerController(context.CustomerAdapterMock.Object, context.Validator.Object);

            return context;
        }
    }
}

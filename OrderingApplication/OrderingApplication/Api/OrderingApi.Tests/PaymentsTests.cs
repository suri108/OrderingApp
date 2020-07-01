using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderingApi.Business;
using OrderingApi.Common.Interfaces;
using OrderingApi.Common.Models;
using OrderingApi.Controllers;
using OrderingApi.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OrderingApi.Tests
{
    public class PaymentsTests
    {
        PaymentsController controller;
        Mock<IPaymentsService> mockPaymentsService;

        public PaymentsTests()
        {
            controller = new PaymentsController(new PaymentsService(new PaymentsFactory()));
            mockPaymentsService = new Mock<IPaymentsService>();
        }

        [Theory]
        [InlineData("Duplicate packing slip for the royalty department is generated. Commission payment to the agent is generated.")]
        public async Task Payment_Book_Works(string expectedResult)
        {
            var response = await controller.ProcessPayment(new Payment { Selection = "book" });

            var result = response as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData("Membership is activated. Email has been sent to owner about activation/upgrade.")]
        public async Task Payment_Membership_Works(string expectedResult)
        {
            var response = await controller.ProcessPayment(new Payment { Selection = "membership" });

            var result = response as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData("Packing slip for shipping is generated. Commission payment to the agent is generated.")]
        public async Task Payment_PhysicalProduct_Works(string expectedResult)
        {
            var response = await controller.ProcessPayment(new Payment { Selection = "physical product" });

            var result = response as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData("Upgrade is applied. Email has been sent to owner about activation/upgrade.")]
        public async Task Payment_Upgrade_Works(string expectedResult)
        {
            var response = await controller.ProcessPayment(new Payment { Selection = "upgrade" });

            var result = response as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData("Added a free “First Aid” video to the packing slip.")]
        public async Task Payment_Video_Works(string expectedResult)
        {
            var response = await controller.ProcessPayment(new Payment { Selection = "learning to ski video" });

            var result = response as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public async Task Payment_InternalServerError()
        {
            mockPaymentsService.Setup(x => x.ProcessPayment(It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            controller = new PaymentsController(mockPaymentsService.Object);
            var response = await controller.ProcessPayment(new Payment { Selection = "book" });

            var result = response as ObjectResult;

            Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
        }
    }
}

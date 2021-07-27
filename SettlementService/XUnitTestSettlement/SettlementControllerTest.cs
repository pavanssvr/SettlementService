using System;
using Xunit;
using Microsoft.Extensions.Caching.Memory;
using SettlementService.Controllers;
using Services;
using Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestSettlement
{
    public class SettlementControllerTest
    {
        IService _service;
        SettlementController _controller;
        public SettlementControllerTest()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            _service = new Service(memoryCache);
            _controller = new SettlementController(_service);
        }

        [Fact]
        public void Post_PassInvalidBookingTime_ReturnsBadRequestObjectResult()
        {
            var request = new Request() { BookingTime = "18:03", Name = "testing" };
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            var badRequestResult = _controller.Post(request);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        }

        [Fact]
        public void Post_PassInvalidRequestObject_ReturnBadRequestObjectResult()
        {
            var request = new Request() { BookingTime = "14:03", Name = "" };
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            var badRequestResult = _controller.Post(request);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        }

        [Fact]
        public void Post_PassValidRequest_ReturnsOkResult()
        {
            var request = new Request() { BookingTime = "10:03", Name = "testing" };
            var okResult = _controller.Post(request);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_PassExistingRequest_ReturnsConflictResult()
        {
            var request = new Request() { BookingTime = "09:03", Name = "testing" };
            var okResult = _controller.Post(request);

            var secondRequest = new Request() { BookingTime = "09:03", Name = "Joshuak" };
            var conflictResult = _controller.Post(secondRequest);

            // Assert
            Assert.IsType<ConflictObjectResult>(conflictResult.Result);
        }

        [Fact]
        public void Post_PassFourRequests_ReturnsConflictResult()
        {
            var request = new Request() { BookingTime = "11:00", Name = "Katerina" };
            var okResult = _controller.Post(request);

            var secondRequest = new Request() { BookingTime = "12:00", Name = "Ritchard" };
            var okResultTwo = _controller.Post(secondRequest);

            var thirdRequest = new Request() { BookingTime = "13:00", Name = "Benjamin" };
            var okResultThree = _controller.Post(thirdRequest);

            var fourthRequest = new Request() { BookingTime = "14:00", Name = "Jonathan" };
            var okResultFour = _controller.Post(fourthRequest);
            // Assert
            Assert.IsType<OkObjectResult>(okResultFour.Result);
        }
    }
}

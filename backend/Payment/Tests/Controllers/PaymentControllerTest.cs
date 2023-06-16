using API.Controllers;
using Domain.DTOs;
using Domain.Enums;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Xunit;

namespace Tests.Controllers
{
    public class PaymentControllerTest
    {
        private readonly Mock<IPaymentService> _paymenntservice;
        private readonly PaymentController _paymentController;
        private readonly Mock<IReadOnlyDictionary<string, ModelStateEntry>> _readonlyDictionary;

        public PaymentControllerTest()
        {
            _paymenntservice = new Mock<IPaymentService>();
            _readonlyDictionary = new Mock<IReadOnlyDictionary<string, ModelStateEntry>>();
            _paymentController = new PaymentController(_paymenntservice.Object);
        }

        [Fact]
        public async Task DoPayment_WithSuccess()
        {
            var result = await _paymentController.DoPayment(new PaymentDTO()
            {
                Description = "teste 1",
                PaymentAmount = 1000,
                PaymentType = PaymentType.Credit,
                PaymentDate = DateTime.Now.AddDays(1).Date,
            });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DoPayment_WithError()
        {
            var result = await _paymentController.DoPayment(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DoPayment_WithManyError()
        {
            _paymentController.ModelState.SetModelValue("erro", false, "erro");

            var result = await _paymentController.DoPayment(new PaymentDTO()
            {
                Description = null,
                PaymentAmount = 0,
                PaymentType = PaymentType.Credit,
                PaymentDate = DateTime.MinValue,
            });

            

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

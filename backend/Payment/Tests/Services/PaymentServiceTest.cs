using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Services
{
    public class PaymentServiceTest
    {
        private readonly Mock<IPaymentRepository> _paymentRepository;
        private readonly IPaymentService _paymentService;

        public PaymentServiceTest()
        {
            _paymentRepository = new Mock<IPaymentRepository>();
            _paymentService = new PaymentService(_paymentRepository.Object);
        }

        [Fact]
        public async Task GetAllTransaction_WithSuccess()
        {
            var payments = new List<Payment>
            {
                new Payment("teste1", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste2", DateTime.Now, PaymentType.Credit, 100),
                new Payment("teste3", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste4", DateTime.Now, PaymentType.Credit, 10),
            };

            _paymentRepository.Setup(x => x.GetAllTransactions()).ReturnsAsync(payments);

            var result = await _paymentService.GetAllTransactions();

            _paymentRepository.Verify(x => x.GetAllTransactions(), Times.Once);

            Assert.Equal(payments.Count(), result.Count());
            Assert.True(result.All(p => payments.Contains(p)));
            Assert.IsType<List<Payment>>(result);
        }
    }
}

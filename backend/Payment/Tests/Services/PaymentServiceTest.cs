using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using Moq;
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

        [Fact]
        public async Task GetTransactionByReferenceDate_WithSuccess()
        {
            var payments = new List<Payment>
            {
                new Payment("teste1", DateTime.Now.AddDays(1), PaymentType.Debit, 100),
                new Payment("teste2", DateTime.Now.AddDays(1), PaymentType.Credit, 100),
                new Payment("teste3", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste4", DateTime.Now, PaymentType.Credit, 10),
            };


            _paymentRepository.Setup(x => x.GetTransactionsByReferenceDate(DateTime.Now.AddDays(1).Date))
                .ReturnsAsync(new PaymentConsolidated(payments, payments.Sum(x => x.PaymentAmount)));

            var result = await _paymentService.GetTransactionsByReferenceDate(DateTime.Now.AddDays(1).Date);


            _paymentRepository.Verify(x => x.GetTransactionsByReferenceDate(DateTime.Now.AddDays(1).Date), Times.Once);

            Assert.Equal(payments.Sum(x => x.PaymentAmount), result.Payments.Sum(x => x.PaymentAmount));
            Assert.Equal(payments.Count(), result.Payments.Count());
            Assert.True(result.Payments.All(p => payments.Contains(p)));
            Assert.IsType<PaymentConsolidated>(result);
        }
    }
}

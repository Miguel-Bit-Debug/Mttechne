using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Models;
using InfraData.Repositories;
using MongoDB.Driver;
using Moq;
using Product.InfraData.Data;
using Xunit;

namespace Tests.Repositories
{
    public class PaymentRepositoryTest
    {
        private readonly Mock<IMongoCollection<Payment>> _mongoCollection;
        private readonly Mock<IMongoDbContext> _mongoDbContext;
        private readonly Mock<IAsyncCursor<Payment>> _cursorPayments;
        private readonly Mock<IAsyncCursor<PaymentConsolidated>> _cursorPaymentConsolidated;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentRepositoryTest()
        {
            _mongoCollection = new Mock<IMongoCollection<Payment>>();
            _cursorPayments = new Mock<IAsyncCursor<Payment>>();
            _cursorPaymentConsolidated = new Mock<IAsyncCursor<PaymentConsolidated>>();
            _mongoDbContext = new Mock<IMongoDbContext>();

            _mongoDbContext.Setup(d => d.Collection<Payment>()).Returns(_mongoCollection.Object);
            _paymentRepository = new PaymentRepository(_mongoDbContext.Object);
        }

        [Fact]
        public async Task GetAllPayments_WithSuccess()
        {
            var payments = new List<Payment>
            {
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
            };

            _cursorPayments.Setup(x => x.Current).Returns(payments);

            _mongoCollection.Setup(c => c.FindAsync(
                    It.IsAny<FilterDefinition<Payment>>(),
                    It.IsAny<FindOptions<Payment, Payment>>(),
                    It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync(_cursorPayments.Object);

            var result = await _paymentRepository.GetAllTransactions();

            _mongoCollection.Verify(x => x.FindAsync(
                    It.IsAny<FilterDefinition<Payment>>(),
                    It.IsAny<FindOptions<Payment, Payment>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);
        }

        [Fact]
        public async Task GetTransactionsByReferenceDate_WithSuccess()
        {
            var payments = new List<Payment>
            {
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
                new Payment("teste", DateTime.Now, PaymentType.Debit, 100),
            };

            var paymentConsolidated = new PaymentConsolidated(payments, payments.Sum(x => x.PaymentAmount));

            _cursorPayments.Setup(x => x.Current)
                .Returns(payments);

            _mongoCollection.Setup(c => c.FindAsync(
                    It.IsAny<FilterDefinition<Payment>>(),
                    It.IsAny<FindOptions<Payment, Payment>>(),
                    It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync(_cursorPayments.Object);

            var result = await _paymentRepository.GetTransactionsByReferenceDate(DateTime.Now.Date);

            _mongoCollection.Verify(x => x.FindAsync(
                    It.IsAny<FilterDefinition<Payment>>(),
                    It.IsAny<FindOptions<Payment, Payment>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);
        }

    }
}

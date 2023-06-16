using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Models;
using InfraData.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using Moq;
using Xunit;

namespace Product.InfraData.Data.Tests
{
    public class MongoRepositoryTests
    {
        private readonly Mock<IMongoCollection<Payment>> _collectionMock;
        private readonly PaymentRepository _paymentRepository;
        private readonly Mock<IAsyncCursor<Payment>> _asyncCursorMock;

        public MongoRepositoryTests()
        {
            _collectionMock = new Mock<IMongoCollection<Payment>>();
            var dbContextMock = new Mock<IMongoDbContext>();
            _asyncCursorMock = new Mock<IAsyncCursor<Payment>>();
            dbContextMock.Setup(d => d.Collection<Payment>()).Returns(_collectionMock.Object);

            _paymentRepository = new PaymentRepository(dbContextMock.Object);
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

            _asyncCursorMock.Setup(x => x.Current).Returns(payments);

            _collectionMock.Setup(c => c.FindAsync(
                    It.IsAny<FilterDefinition<Payment>>(),
                    It.IsAny<FindOptions<Payment, Payment>>(),
                    It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync(_asyncCursorMock.Object);

            var result = await _paymentRepository.GetAllTransactions();

            _collectionMock.Verify(x => x.FindAsync(
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

            _asyncCursorMock.Setup(x => x.Current)
                .Returns(payments);

            _collectionMock.Setup(c => c.FindAsync(
                    It.IsAny<FilterDefinition<Payment>>(),
                    It.IsAny<FindOptions<Payment, Payment>>(),
                    It.IsAny<CancellationToken>()
                ))
                .ReturnsAsync(_asyncCursorMock.Object);

            var result = await _paymentRepository.GetTransactionsByReferenceDate(DateTime.Now.Date);

            _collectionMock.Verify(x => x.FindAsync(
                    It.IsAny<FilterDefinition<Payment>>(),
                    It.IsAny<FindOptions<Payment, Payment>>(),
                    It.IsAny<CancellationToken>()
                ), Times.Once);
        }



        [Fact]
        public async Task SaveTransactionWithSuccess()
        {
            // Arrange
            var payment = new Payment("teste", DateTime.Now, PaymentType.Debit, 100);

            // Act
            await _paymentRepository.SaveTransaction(payment);

            // Assert
            _collectionMock.Verify(c => c.InsertOneAsync(payment, null, default), Times.Once);

        }
    }
}

using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetAllTransactions()
        {
            var payments = await _paymentRepository.GetAllTransactions();
            return payments;
        }

        public async Task<PaymentConsolidated> GetTransactionsByReferenceDate(DateTime referenceDate)
        {
            var payments = await _paymentRepository.GetTransactionsByReferenceDate(referenceDate.Date);
            return payments;
        }

        public async Task SaveTransaction(PaymentDTO paymentDTO)
        {
            var payment = new Payment(paymentDTO.Description,
                                      paymentDTO.PaymentDate.Date,
                                      paymentDTO.PaymentType,
                                      paymentDTO.PaymentAmount);

            await _paymentRepository.SaveTransaction(payment);
        }
    }
}

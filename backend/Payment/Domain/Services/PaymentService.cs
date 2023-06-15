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

        public async Task SaveTransaction(PaymentDTO paymentDTO)
        {
            var payment = new Payment(paymentDTO.Desciption,
                                      paymentDTO.PaymentDate,
                                      paymentDTO.PaymentType,
                                      paymentDTO.PaymentAmount);

            await _paymentRepository.SaveTransaction(payment);
        }
    }
}

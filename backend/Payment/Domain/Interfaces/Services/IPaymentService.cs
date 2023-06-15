using Domain.DTOs;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPaymentService
{
    Task SaveTransaction(PaymentDTO paymentDTO);
}

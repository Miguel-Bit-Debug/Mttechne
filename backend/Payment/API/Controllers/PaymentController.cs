using Domain.DTOs;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Endpoint para realizar uma transação
    /// </summary>
    /// <param name="payment"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> DoPayment([FromBody] PaymentDTO payment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Select(x => x.Value?.Errors).ToList());
        }

        if (payment == null)
        {
            return BadRequest(new { message = "invalid payload" });
        }

        await _paymentService.SaveTransaction(payment);

        return Ok(new { message = "payment realized." });
    }

    /// <summary>
    /// Endpoint para buscar transações por data de referencia e trazer o valor consolidado daquele dia
    /// </summary>
    /// <param name="referenceDate"></param>
    /// <returns></returns>
    [HttpGet("payments-filter-date/{referenceDate}")]
    public async Task<IActionResult> GetPaymentsByReferenceDate([FromRoute] DateTime referenceDate)
    {
        var payments = await _paymentService.GetTransactionsByReferenceDate(referenceDate);
        return Ok(payments);
    }

    /// <summary>
    /// Endpoint para buscar todas as transações
    /// </summary>
    /// <returns></returns>
    [HttpGet("payments")]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await _paymentService.GetAllTransactions();
        return Ok(payments);
    }
}

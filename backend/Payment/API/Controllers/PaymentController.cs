using Domain.DTOs;
using Domain.Interfaces.Repositories;
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

    [HttpPost]
    public async Task<IActionResult> DoPayment([FromBody] PaymentDTO paymentDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Select(x => x.Value?.Errors).ToList());
        }

        await _paymentService.SaveTransaction(paymentDTO);

        return Ok(new { message = "payment realized." });
    }
}

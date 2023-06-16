using Domain.Enums;

namespace Domain.Models;

public class Payment : Entity
{
    public Payment(string desciption,
                   DateTime paymentDate,
                   PaymentType paymentType,
                   decimal paymentAmount)
    {
        Description = desciption;
        PaymentDate = paymentDate;
        PaymentType = paymentType;
        PaymentAmount = paymentAmount;
    }

    public string Description { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public PaymentType PaymentType { get; private set; }
    public decimal PaymentAmount { get; private set; }
}

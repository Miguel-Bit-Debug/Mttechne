using System.ComponentModel;

namespace Domain.Enums;

public enum PaymentType
{
    [Description("Credit")]
    Credit = 1,
    [Description("Debit")]
    Debit = 2
}

using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.API.Business.Domain.Extensions;
using CustomerBase.API.Business.Domain.Handlers.ValidationHandler;
using FluentValidation;

namespace CustomerBase.API.Business.Domain.EntitiesValidation;
public sealed class TelephoneValidation : Validate<Telephone>
{
    public TelephoneValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(t => t.Ddi).NotEmpty().Length(2, 6)
               .WithMessage(t => string.IsNullOrWhiteSpace(t.Ddi)
               ? EMessage.Required.GetDescription().FormatTo("DDI")
               : EMessage.MoreExpected.GetDescription().FormatTo("DDI", "entre {MinLength} e {MaxLength}"));

        When(t => t.TelephoneType == ETelephoneType.Landline, () =>
        {
            RuleFor(t => t.PhoneNumber).NotEmpty().Length(8, 9)
               .WithMessage(t => string.IsNullOrWhiteSpace(t.PhoneNumber)
               ? EMessage.Required.GetDescription().FormatTo("Número de telefone")
               : EMessage.MoreExpected.GetDescription().FormatTo("Número de telefone", "entre {MinLength} e {MaxLength}"));
        });

        When(t => t.TelephoneType == ETelephoneType.CellPhone, () =>
        {
            RuleFor(t => t.PhoneNumber).NotEmpty().Length(9, 10)
               .WithMessage(t => string.IsNullOrWhiteSpace(t.PhoneNumber)
               ? EMessage.Required.GetDescription().FormatTo("Número do celular")
               : EMessage.MoreExpected.GetDescription().FormatTo("Número do celular", "entre {MinLength} e {MaxLength}"));
        });

        When(t => t.Ddd is not null, () =>
        {
            RuleFor(t => t.Ddd).NotEmpty().Length(2, 3)
                .WithMessage(t => string.IsNullOrWhiteSpace(t.Ddd)
                ? EMessage.Required.GetDescription().FormatTo("DDD")
                : EMessage.MoreExpected.GetDescription().FormatTo("DDD", "entre {MinLength} e {MaxLength}"));
        });
    }
}

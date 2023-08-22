using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.API.Business.Domain.Extensions;
using CustomerBase.API.Business.Domain.Handlers.ValidationHandler;
using FluentValidation;

namespace CustomerBase.API.Business.Domain.EntitiesValidation;
public sealed class AddressValidation : Validate<Address>
{
    public AddressValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(a => a.AddressType).IsInEnum().WithMessage(EMessage.InvalidFormat.GetDescription().FormatTo("Tipo de endereço"));

        RuleFor(a => a.Localization).NotEmpty().Length(3, 100)
            .WithMessage(a => string.IsNullOrWhiteSpace(a.Localization)
            ? EMessage.Required.GetDescription().FormatTo("Localização / Rua")
            : EMessage.MoreExpected.GetDescription().FormatTo("Localização / Rua", "entre {MinLength} e {MaxLength}"));

        RuleFor(a => a.District).NotEmpty().Length(3, 70)
            .WithMessage(a => string.IsNullOrWhiteSpace(a.District)
           ? EMessage.Required.GetDescription().FormatTo("Bairro")
           : EMessage.MoreExpected.GetDescription().FormatTo("Bairro", "entre {MinLength} e {MaxLength}"));

        RuleFor(a => a.City).NotEmpty().Length(3, 70)
            .WithMessage(a => string.IsNullOrWhiteSpace(a.City)
           ? EMessage.Required.GetDescription().FormatTo("Cidade")
           : EMessage.MoreExpected.GetDescription().FormatTo("Cidade", "entre {MinLength} e {MaxLength}"));

        RuleFor(a => a.State).NotEmpty().Length(2, 50)
            .WithMessage(a => string.IsNullOrWhiteSpace(a.State)
           ? EMessage.Required.GetDescription().FormatTo("Estado / Uf")
           : EMessage.MoreExpected.GetDescription().FormatTo("Estado / Uf", "entre {MinLength} e {MaxLength}"));

        RuleFor(a => a.Country).NotEmpty().Length(3, 70)
            .WithMessage(a => string.IsNullOrWhiteSpace(a.Country)
           ? EMessage.Required.GetDescription().FormatTo("País")
           : EMessage.MoreExpected.GetDescription().FormatTo("País", "entre {MinLength} e {MaxLength}"));

        RuleFor(a => a.ZipCode).NotEmpty().NotEmpty().Length(8, 20)
            .WithMessage(a => string.IsNullOrWhiteSpace(a.ZipCode)
           ? EMessage.Required.GetDescription().FormatTo("Cep")
           : EMessage.MoreExpected.GetDescription().FormatTo("Cep", "entre {MinLength} e {MaxLength}"));

        RuleFor(a => a.Number).NotEmpty().Length(1, 15)
            .WithMessage(a => string.IsNullOrWhiteSpace(a.Number)
           ? EMessage.Required.GetDescription().FormatTo("Numero")
           : EMessage.MoreExpected.GetDescription().FormatTo("Numero", "entre {MinLength} e {MaxLength}"));

        When(a => a.Complement is not null, () =>
        {
            RuleFor(a => a.Complement).NotEmpty().Length(3, 100)
                .WithMessage(a => string.IsNullOrWhiteSpace(a.Complement)
                ? EMessage.Required.GetDescription().FormatTo("Complemento")
                : EMessage.MoreExpected.GetDescription().FormatTo("Complemento", "entre {MinLength} e {MaxLength}"));
        });
    }
}

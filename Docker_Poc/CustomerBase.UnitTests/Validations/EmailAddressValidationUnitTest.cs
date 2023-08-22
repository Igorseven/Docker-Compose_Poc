using Bogus.Extensions;
using CustomerBase.API.Business.Domain.EntitiesValidation;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Builders;

namespace Customer.UnitTest.Validations;
public sealed class EmailAddressValidationUnitTest
{
    private readonly EmailAddressValidation _validation;

    public EmailAddressValidationUnitTest()
    {
        _validation = new();
    }

    [Fact]
    [Trait("Success", "Perfect setting")]
    public async Task EmailAddressValidation_PerfectSetting_ReturnTrue()
    {
        var email = "email@test.com";
        var emailType = EEmailType.Main;

        var emailAddress = EmailAddressBuilderTest.NewObject()
                                                  .WithEmailType(emailType)
                                                  .WithEmail(email)
                                                  .DomainObject();

        var validationResponse = await _validation.ValidationAsync(emailAddress);

        Assert.True(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidEmail()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Person.Email.ClampLength(1, 6)},
            new object[] {new Bogus.Faker().Person.Email.ClampLength(151, 155)},
            new object[] {new Bogus.Faker().Person.FirstName.ClampLength(8, 10)},
            new object[] {"user.hotmail.com"},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid Email")]
    [MemberData(nameof(InvalidEmail))]
    public async Task EmailAddressValidation_InvalidEmail_ReturnFalse(string email)
    {
        var emailType = EEmailType.Main;

        var emailAddress = EmailAddressBuilderTest.NewObject()
                                                  .WithEmailType(emailType)
                                                  .WithEmail(email)
                                                  .DomainObject();

        var validationResponse = await _validation.ValidationAsync(emailAddress);

        Assert.False(validationResponse.Valid);
    }


}

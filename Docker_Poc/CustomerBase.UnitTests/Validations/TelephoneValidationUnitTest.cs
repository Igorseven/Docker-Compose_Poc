using Bogus.Extensions;
using CustomerBase.API.Business.Domain.EntitiesValidation;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Builders;

namespace CustomerBase.UnitTests.Validations;
public sealed class TelephoneValidationUnitTest
{
    private readonly TelephoneValidation _validation;

    public TelephoneValidationUnitTest()
    {
        _validation = new();
    }

    [Fact]
    [Trait("Success", "Successful cell phone validation with all data")]
    public async Task TelephoneValidation_ValidCellPhoneAllData_ReturnTrue()
    {
        var telephoneType = ETelephoneType.CellPhone;
        var ddi = "55";
        var ddd = "018";
        var phoneNumber = "910774488";

        var telephone = TelephoneBuilderTest.NewObject()
                                            .WithETelephoneType(telephoneType)
                                            .WithDdi(ddi)
                                            .WithDdd(ddd)
                                            .WithPhoneNumber(phoneNumber)
                                            .DomainObject();

        var validationResponse = await _validation.ValidationAsync(telephone);

        Assert.True(validationResponse.Valid);
    }

    [Fact]
    [Trait("Success", "Successful telephone validation with all data")]
    public async Task TelephoneValidation_ValidTelePhoneAllData_ReturnTrue()
    {
        var telephoneType = ETelephoneType.Landline;
        var ddi = "55";
        var ddd = "018";
        var phoneNumber = "33711546";

        var telephone = TelephoneBuilderTest.NewObject()
                                            .WithETelephoneType(telephoneType)
                                            .WithDdi(ddi)
                                            .WithDdd(ddd)
                                            .WithPhoneNumber(phoneNumber)
                                            .DomainObject();

        var validationResponse = await _validation.ValidationAsync(telephone);

        Assert.True(validationResponse.Valid);
    }

    [Fact]
    [Trait("Success", "Successful international mobile phone validation data")]
    public async Task TelephoneValidation_ValidCellPhoneData_ReturnTrue()
    {
        var telephoneType = ETelephoneType.CellPhone;
        var ddi = "351";
        var phoneNumber = "910774488";

        var telephone = TelephoneBuilderTest.NewObject()
                                            .WithETelephoneType(telephoneType)
                                            .WithDdi(ddi)
                                            .WithDdd(null)
                                            .WithPhoneNumber(phoneNumber)
                                            .DomainObject();

        var validationResponse = await _validation.ValidationAsync(telephone);

        Assert.True(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidDdi()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(7, 8)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid DDI")]
    [MemberData(nameof(InvalidDdi))]
    public async Task TelephoneValidation_InvalidDdi_ReturnFalse(string ddi)
    {
        var telephoneType = ETelephoneType.CellPhone;
        var ddd = "018";
        var phoneNumber = "910774488";

        var telephone = TelephoneBuilderTest.NewObject()
                                            .WithETelephoneType(telephoneType)
                                            .WithDdi(ddi)
                                            .WithDdd(ddd)
                                            .WithPhoneNumber(phoneNumber)
                                            .DomainObject();

        var validationResponse = await _validation.ValidationAsync(telephone);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidDdd()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(4, 5)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid DDD")]
    [MemberData(nameof(InvalidDdd))]
    public async Task TelephoneValidation_InvalidDdd_ReturnFalse(string ddd)
    {
        var telephoneType = ETelephoneType.CellPhone;
        var ddi = "55";
        var phoneNumber = "910774488";

        var telephone = TelephoneBuilderTest.NewObject()
                                            .WithETelephoneType(telephoneType)
                                            .WithDdi(ddi)
                                            .WithDdd(ddd)
                                            .WithPhoneNumber(phoneNumber)
                                            .DomainObject();

        var validationResponse = await _validation.ValidationAsync(telephone);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidCellPhoneNumber()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 8)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(11, 12)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid Cell phone number")]
    [MemberData(nameof(InvalidCellPhoneNumber))]
    public async Task TelephoneValidation_InvalidCellPhoneNumber_ReturnFalse(string phoneNumber)
    {
        var telephoneType = ETelephoneType.CellPhone;
        var ddi = "55";
        var ddd = "018";

        var telephone = TelephoneBuilderTest.NewObject()
                                            .WithETelephoneType(telephoneType)
                                            .WithDdi(ddi)
                                            .WithDdd(ddd)
                                            .WithPhoneNumber(phoneNumber)
                                            .DomainObject();

        var validationResponse = await _validation.ValidationAsync(telephone);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidTelePhoneNumber()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 7)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(10, 11)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid Telephone number")]
    [MemberData(nameof(InvalidTelePhoneNumber))]
    public async Task TelephoneValidation_InvalidTelePhoneNumber_ReturnFalse(string phoneNumber)
    {
        var telephoneType = ETelephoneType.Landline;
        var ddi = "55";
        var ddd = "018";

        var telephone = TelephoneBuilderTest.NewObject()
                                            .WithETelephoneType(telephoneType)
                                            .WithDdi(ddi)
                                            .WithDdd(ddd)
                                            .WithPhoneNumber(phoneNumber)
                                            .DomainObject();

        var validationResponse = await _validation.ValidationAsync(telephone);

        Assert.False(validationResponse.Valid);
    }
}

using Bogus.Extensions;
using CustomerBase.API.Business.Domain.EntitiesValidation;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Builders;

namespace CustomerBase.UnitTests.Validations;
public sealed class AddressValidationUnitTest
{
    private readonly AddressValidation _validation;

    public AddressValidationUnitTest()
    {
        _validation = new();
    }

    [Fact]
    [Trait("Success", "Successful validation with all data")]
    public async Task AddressValidation_ValidWithAllData_ReturnTrue()
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var state = "TS";
        var country = "País Teste";
        var complement = "Complemento teste";
        var zipCode = "70008000";

        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithComplement(complement)
                                        .WithZipCode(zipCode)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.True(validationResponse.Valid);
    }


    [Fact]
    [Trait("Success", "Successful validation with partial data")]
    public async Task AddressValidation_ValidWithPartialData_ReturnTrue()
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var state = "TS";
        var country = "País Teste";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;
        string? complement = null;


        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.True(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidLocalization()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(101, 150)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid localization")]
    [MemberData(nameof(InvalidLocalization))]
    public async Task AddressValidation_InvalidLocalization_ReturnFalse(string localization)
    {
        var district = "Bairro dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var state = "TS";
        var country = "País Teste";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;
        string? complement = null;


        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidDistrict()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(71, 100)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid district")]
    [MemberData(nameof(InvalidDistrict))]
    public async Task AddressValidation_InvalidDistrict_ReturnFalse(string district)
    {
        var localization = "Rua dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var state = "TS";
        var country = "País Teste";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;
        string? complement = null;


        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidNumber()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(16, 20)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid number")]
    [MemberData(nameof(InvalidNumber))]
    public async Task AddressValidation_InvalidNumber_ReturnFalse(string number)
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var city = "Cidade teste";
        var state = "TS";
        var country = "País Teste";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;
        string? complement = null;


        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidCity()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(71, 90)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid city")]
    [MemberData(nameof(InvalidCity))]
    public async Task AddressValidation_InvalidCity_ReturnFalse(string city)
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var number = "1A";
        var state = "TS";
        var country = "País Teste";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;
        string? complement = null;


        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidState()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(51, 70)},
            new object[] {"S"},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid state")]
    [MemberData(nameof(InvalidState))]
    public async Task AddressValidation_InvalidState_ReturnFalse(string state)
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var country = "País Teste";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;
        string? complement = null;


        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidCountry()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(71, 90)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid country")]
    [MemberData(nameof(InvalidCountry))]
    public async Task AddressValidation_InvalidCountry_ReturnFalse(string country)
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var state = "TS";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;
        string? complement = null;

        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidZipCode()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 7)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(21, 40)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid zip code")]
    [MemberData(nameof(InvalidZipCode))]
    public async Task AddressValidation_InvalidZipCode_ReturnFalse(string zipCode)
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var state = "TS";
        var country = "País Teste";
        var addressType = EAddressType.MainProperty;
        string? complement = null;

        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }


    public static IEnumerable<object[]> InvalidComplement()
    {
        return new List<object[]>
        {
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(1, 2)},
            new object[] {new Bogus.Faker().Address.StreetAddress().ClampLength(101, 120)},
            new object[] {""},
            new object[] {"      "},
        };
    }

    [Theory]
    [Trait("Failed", "Invalid complement")]
    [MemberData(nameof(InvalidComplement))]
    public async Task AddressValidation_InvalidComplement_ReturnFalse(string complement)
    {
        var localization = "Rua dos testes";
        var district = "Bairro dos testes";
        var number = "1A";
        var city = "Cidade teste";
        var state = "TS";
        var country = "País Teste";
        var zipCode = "70008000";
        var addressType = EAddressType.MainProperty;

        var address = AddressBuilderTest.NewObject()
                                        .WithLocalization(localization)
                                        .WithDistrict(district)
                                        .WithCity(city)
                                        .WithState(state)
                                        .WithNumber(number)
                                        .WithCountry(country)
                                        .WithZipCode(zipCode)
                                        .WithComplement(complement)
                                        .WithAddressType(addressType)
                                        .DomainObject();

        var validationResponse = await _validation.ValidationAsync(address);

        Assert.False(validationResponse.Valid);
    }
}

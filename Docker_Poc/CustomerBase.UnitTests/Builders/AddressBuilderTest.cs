using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.UnitTests.Builders;
public sealed class AddressBuilderTest
{
    private int _addressId = 1;
    private EAddressType _addressType = EAddressType.MainProperty;
    private string _localization = "Rua Test";
    private string _district = "Bairro Test";
    private string _city = "Cidade Test";
    private string _state = "TS";
    private string _number = "777";
    private string _zipCode = "70006000";
    private string? _complement = null;
    private string _country = "País Test";
    private int _customerId = 1;

    public static AddressBuilderTest NewObject() => new();

    public Address DomainObject() =>
        new()
        {
            AddressId = _addressId,
            AddressType = _addressType,
            Country = _country,
            State = _state,
            ZipCode = _zipCode,
            City = _city,
            District = _district,
            Localization = _localization,
            Complement = _complement,
            Number = _number,
            CustomerId = _customerId
        };

    public AddressBuilderTest WithId(int id)
    {
        _addressId = id;
        return this;
    }

    public AddressBuilderTest WithCountry(string country)
    {
        _country = country;
        return this;
    } 
    
    public AddressBuilderTest WithAddressType(EAddressType addressType)
    {
        _addressType = addressType;
        return this;
    }

    public AddressBuilderTest WithState(string state)
    {
        _state = state;
        return this;
    }

    public AddressBuilderTest WithZipCode(string zipCode)
    {
        _zipCode = zipCode;
        return this;
    }

    public AddressBuilderTest WithCity(string city)
    {
        _city = city;
        return this;
    }

    public AddressBuilderTest WithDistrict(string district)
    {
        _district = district;
        return this;
    }

    public AddressBuilderTest WithLocalization(string localization)
    {
        _localization = localization;
        return this;
    }

    public AddressBuilderTest WithComplement(string? complement)
    {
        _complement = complement;
        return this;
    }

    public AddressBuilderTest WithNumber(string number)
    {
        _number = number;
        return this;
    }


}

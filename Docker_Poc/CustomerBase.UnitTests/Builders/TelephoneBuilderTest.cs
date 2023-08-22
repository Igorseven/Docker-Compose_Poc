using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.UnitTests.Builders;
public sealed class TelephoneBuilderTest
{
    private int _telephoneId = 1;
    private ETelephoneType _telephoneType = ETelephoneType.CellPhone;
    private string _ddi = "55";
    private string? _ddd = null;
    private string _phoneNumber = "910734688";
    private int _customerId = 1;

    public static TelephoneBuilderTest NewObject() => new();

    public Telephone DomainObject() =>
        new()
        {
            TelephoneId = _telephoneId,
            Ddi = _ddi,
            Ddd = _ddd,
            PhoneNumber = _phoneNumber,
            TelephoneType = _telephoneType,
            CustomerId = _customerId
        };

    public TelephoneBuilderTest WithId(int telephoneId)
    {
        _telephoneId = telephoneId;
        return this;
    }
    
    public TelephoneBuilderTest WithETelephoneType(ETelephoneType telephoneType)
    {
        _telephoneType = telephoneType;
        return this;
    }

    public TelephoneBuilderTest WithDdi(string ddi)
    {
        _ddi = ddi;
        return this;
    }

    public TelephoneBuilderTest WithDdd(string? ddd)
    {
        _ddd = ddd;
        return this;
    }

    public TelephoneBuilderTest WithPhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
        return this;
    }

    public TelephoneBuilderTest WithCustomerId(int customerId)
    {
        _customerId = customerId;
        return this;
    }


}

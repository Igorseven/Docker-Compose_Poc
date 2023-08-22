using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.UnitTests.Builders;
public sealed class EmailAddressBuilderTest
{
    private int _emailAddressId = 1;
    private EEmailType _emailType = EEmailType.Main;
    private string _email = "email@test.com";
    private int _customerId = 1;

    public static EmailAddressBuilderTest NewObject() => new();

    public EmailAddress DomainObject() =>
        new()
        {
            EmailAddressId = _emailAddressId,
            Email = _email,
            EmailType = _emailType,
            CustomerId = _customerId
        };

    public EmailAddressBuilderTest WithId(int emailAddressId)
    {
        _emailAddressId = emailAddressId;
        return this;
    }

    public EmailAddressBuilderTest WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public EmailAddressBuilderTest WithEmailType(EEmailType emailType)
    {
        _emailType = emailType;
        return this;
    }

    public EmailAddressBuilderTest WithCustomerId(int customerId)
    {
        _customerId = customerId;
        return this;
    }


}

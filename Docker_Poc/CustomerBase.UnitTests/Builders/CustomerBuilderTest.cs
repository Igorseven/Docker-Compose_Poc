
using CustomerBase.API.Business.Domain.Entities;

namespace CustomerBase.UnitTests.Builders;
public sealed class CustomerBuilderTest
{
    private int _customerId = 1;
    private string _fullName = "Customer full name";
    private List<Address> _addresses = new();
    private List<Telephone> _telephones = new();
    private List<EmailAddress> _emails = new();

    public static CustomerBuilderTest NewObject() => new();

    public CustomerBase.API.Business.Domain.Entities.Customer DomainObject() =>
        new()
        {
            CustomerId = _customerId,
            FullName = _fullName,
            Addresses = _addresses,
            Telephones = _telephones,
            Emails = _emails
        };

    public CustomerBuilderTest WithId(int customerId)
    {
        _customerId = customerId;
        return this;
    }

    public CustomerBuilderTest WithFullName(string fullName)
    {
        _fullName = fullName;
        return this;
    }

    public CustomerBuilderTest WithAddresses(Address address)
    {
        _addresses.Add(address);
        return this;
    }

    public CustomerBuilderTest WithTelephones(Telephone telephone)
    {
        _telephones.Add(telephone);
        return this;
    }

    public CustomerBuilderTest WithEmails(EmailAddress emailAddress)
    {
        _emails.Add(emailAddress);
        return this;
    }

    public CustomerBuilderTest WithAllRelationships()
    {
        var email = EmailAddressBuilderTest.NewObject().DomainObject();
        var telphone = TelephoneBuilderTest.NewObject().DomainObject();
        var address = AddressBuilderTest.NewObject().DomainObject();

        _emails.Add(email);
        _telephones.Add(telphone);
        _addresses.Add(address);

        return this;
    }
}

using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Mappers.EmailAddressMappers.Base;

namespace CustomerBase.UnitTests.Mappers.EmailAddressMappers;
public sealed class DomainToCustomerDtoResponseMethodUnitTest : EmailAddressMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to customer response")]
    public void DomainToCustomerDtoResponse_ResponseEmailAddressCustomerResponse()
    {
        var emailAddress = new EmailAddress
        {
            EmailAddressId = 1,
            Email = "email@test.com",
            EmailType = EEmailType.Main,
            CustomerId = 1
        };

        var mappingResult = _emailAddressMapper.DomainToCustomerDtoResponse(emailAddress);

        Assert.NotNull(mappingResult);
        Assert.Equal(emailAddress.EmailAddressId, mappingResult.EmailAddressId);
        Assert.Equal(emailAddress.Email, mappingResult.Email);
        Assert.Equal(emailAddress.EmailType, mappingResult.EmailType);
    }


    [Fact]
    [Trait("Mapping", "Domain to customer list response")]
    public void DomainToCustomerDtoResponse_ResponseEmailAddressCustomerResponseList()
    {
        var emailAddresses = new List<EmailAddress>()
        {
            new EmailAddress
            {
                EmailAddressId = 1,
                Email = "email@test.com",
                EmailType = EEmailType.Main,
                CustomerId = 1
            }
        };

        var mappingResult = _emailAddressMapper.DomainToCustomerDtoResponse(emailAddresses);

        Assert.NotEmpty(mappingResult);
        Assert.True(mappingResult.Count == 1);

    }
}

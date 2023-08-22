using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Mappers.EmailAddressMappers.Base;

namespace CustomerBase.UnitTests.Mappers.EmailAddressMappers;
public sealed class DtoRegisterToDomainMethodUnitTest : EmailAddressMapperSetup
{
    [Fact]
    [Trait("Mapping", "Dto register to domain")]
    public void DtoRegisterToDomain_ReturnEmailAddress()
    {
        var dtoEmail = new EmailAddressCustomerRegisterRequest
        {
            EmailType = EEmailType.Main,
            Email = "email@test.com"
        };

        var mappingResult = _emailAddressMapper.DtoRegisterToDomain(dtoEmail);

        Assert.NotNull(mappingResult);
        Assert.Equal(dtoEmail.EmailType, mappingResult.EmailType);
        Assert.Equal(dtoEmail.Email, mappingResult.Email);
    }


    [Fact]
    [Trait("Mapping", "Dto register to domain object list")]
    public void DtoRegisterToDomain_ReturnEmailAddressList()
    {
        var dtoEmails = new List<EmailAddressCustomerRegisterRequest>()
        {
            new EmailAddressCustomerRegisterRequest
            {
                EmailType = EEmailType.Main,
                Email = "email@test.com"
            }
        };

        var mappingResult = _emailAddressMapper.DtoRegisterToDomain(dtoEmails);

        Assert.NotEmpty(mappingResult);
        Assert.True(mappingResult.Count == 1);
    }
}

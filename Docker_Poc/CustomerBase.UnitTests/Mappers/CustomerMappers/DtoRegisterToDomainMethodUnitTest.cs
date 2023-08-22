using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Mappers.CustomerMappers.Base;
using Moq;

namespace CustomerBase.UnitTests.Mappers.CustomerMappers;
public sealed class DtoRegisterToDomainMethodUnitTest : CustomerMapperSetup
{
    public static IEnumerable<object[]> CreateCustomerRegisterRequest()
    {
        yield return new object[]
        {
            new CustomerRegisterRequest
            {
                FullName = "User full name",
                Emails = new List<EmailAddressCustomerRegisterRequest>()
                {
                    new()
                    {
                        EmailType = EEmailType.Main,
                        Email = "email@test.com"
                    }
                },
                Phones = new List<TelephoneCustomerRegisterRequest>()
                {
                    new()
                    {
                        Ddi = "+55",
                        Ddd = "(18)",
                        PhoneNumber = "91172-4588",
                        TelephoneType = ETelephoneType.CellPhone
                    },
                    new()
                    {
                        Ddi = "+55",
                        Ddd = "(18)",
                        PhoneNumber = "3371-1566",
                        TelephoneType = ETelephoneType.Landline
                    }
                },
                Addresses = new List<AddressCustomerRegisterRequest>()
                {
                    new()
                    {
                        AddressType = EAddressType.MainProperty,
                        Localization = "Localization",
                        District = "District",
                        City = "City",
                        Number = "12B",
                        State = "SP",
                        Country = "Country",
                        ZipCode = "80009000",
                        Complement = null
                    }
                }
            }
        };
    }

    [Theory]
    [Trait("Mapping", "Dto register to domain")]
    [MemberData(nameof(CreateCustomerRegisterRequest))]
    public void DtoRegisterToDomain_ReturnCustomer(CustomerRegisterRequest dtoCustomer)
    {
        _addressMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<List<AddressCustomerRegisterRequest>>())).Returns(It.IsAny<List<Address>>());
        _emailAddressMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<List<EmailAddressCustomerRegisterRequest>>())).Returns(It.IsAny<List<EmailAddress>>());
        _telephoneMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<List<TelephoneCustomerRegisterRequest>>())).Returns(It.IsAny<List<Telephone>>());

        var mappingResult = _customerMapper.DtoRegisterToDomain(dtoCustomer);

        Assert.NotNull(mappingResult);
        Assert.Equal(dtoCustomer.FullName, mappingResult.FullName);
        _addressMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<List<AddressCustomerRegisterRequest>>()), Times.Once());
        _emailAddressMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<List<EmailAddressCustomerRegisterRequest>>()), Times.Once());
        _telephoneMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<List<TelephoneCustomerRegisterRequest>>()), Times.Once());
    }


}

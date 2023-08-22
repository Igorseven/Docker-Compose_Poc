using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Services.CustomerCommandServiceUnitTest.Base;
using Moq;

namespace CustomerBase.UnitTests.Services.CustomerCommandServiceUnitTest;
public sealed class CustomerRegisterAsyncMethodUnitTest : CustomerCommandServiceSetup
{

    public static IEnumerable<object[]> CustomerRegisterRequestPerfectSetting()
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
    [Trait("Success", "Perfect setting")]
    [MemberData(nameof(CustomerRegisterRequestPerfectSetting))]
    public async Task CustomerRegisterAsync_PerfectSetting_ReturnTrue(CustomerRegisterRequest customerRegisterRequest)
    {
        _customerMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<CustomerRegisterRequest>())).Returns(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>());
        _validate.Setup(v => v.ValidationAsync(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>())).ReturnsAsync(_validationResponse);
        _customerRepository.Setup(r => r.SaveAsync(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>())).ReturnsAsync(true);

        var serviceResult = await _customerCommandService.CustomerRegisterAsync(customerRegisterRequest);

        Assert.True(serviceResult);
        _customerMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<CustomerRegisterRequest>()), Times.Once());
        _validate.Verify(v => v.ValidationAsync(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Once());
        _customerRepository.Verify(r => r.SaveAsync(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Once());
    }


    [Fact]
    [Trait("Failed", "Invalid data")]
    public async Task CustomerRegisterAsync_InvalidData_ReturnFalse()
    {
        CreateInvalidDataNotification();
        _customerMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<CustomerRegisterRequest>())).Returns(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>());
        _validate.Setup(v => v.ValidationAsync(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>())).ReturnsAsync(_validationResponse);

        var serviceResult = await _customerCommandService.CustomerRegisterAsync(It.IsAny<CustomerRegisterRequest>());

        Assert.False(serviceResult);
        _customerMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<CustomerRegisterRequest>()), Times.Once());
        _validate.Verify(v => v.ValidationAsync(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Once());
        _customerRepository.Verify(r => r.SaveAsync(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Never());
    }
}

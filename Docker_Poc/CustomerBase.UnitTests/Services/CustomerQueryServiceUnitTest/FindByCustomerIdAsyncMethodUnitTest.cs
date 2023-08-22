using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Builders;
using CustomerBase.UnitTests.Services.CustomerQueryServiceUnitTest.Base;
using CustomerBase.UnitTests.UnitTest;
using Moq;

namespace CustomerBase.UnitTests.Services.CustomerQueryServiceUnitTest;
public sealed class FindByCustomerIdAsyncMethodUnitTest : CustomerQueryServiceSetup
{
    [Fact]
    [Trait("Query", "Return dto CustomerWithEmailAndMainAddressResponse")]
    public async Task FindByCustomerIdAsync_ResponseCustomerWithEmailAndMainAddressResponse()
    {
        var customerId = 1;
        var customer = CustomerBuilderTest.NewObject().DomainObject();
        var dtoCustoemr = new CustomerWithEmailAndMainAddressResponse
        {
            CustomerId = 1,
            FullName = "Customer full name",
            Email = "email@test.com",
            Address = new AddressCustomerResponse
            {
                AddressId = 1,
                AddressType = EAddressType.MainProperty,
                Localization = "Localization",
                District = "District",
                City = "City",
                Country = "Country",
                Number = "15A",
                State = "state",
                ZipCode = "80009000",
                Complement = null
            }
        };

        _customerRepository.Setup(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                              UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                              true)).ReturnsAsync(customer);
        _customerMapper.Setup(m => m.DomainToEmailAndMainAddressDtoResponse(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>())).Returns(dtoCustoemr);

        var serviceResult = await _customerQueryService.FindByCustomerIdAsync(customerId);

        Assert.NotNull(serviceResult);
        _customerRepository.Verify(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                               UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                               true), Times.Once());
        _customerMapper.Verify(m => m.DomainToEmailAndMainAddressDtoResponse(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Once());
    }


    [Fact]
    [Trait("Query", "Return null")]
    public async Task FindByCustomerIdAsync_ResponseNull()
    {
        var customerId = 1;

        _customerRepository.Setup(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                              UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                              true));

        var serviceResult = await _customerQueryService.FindByCustomerIdAsync(customerId);

        Assert.Null(serviceResult);
        _customerRepository.Verify(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                               UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>(),
                                                               true), Times.Once());
        _customerMapper.Verify(m => m.DomainToEmailAndMainAddressDtoResponse(It.IsAny<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Never());
    }
}

using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using CustomerBase.UnitTests.Builders;
using CustomerBase.UnitTests.Services.CustomerQueryServiceUnitTest.Base;
using CustomerBase.UnitTests.UnitTest;
using Moq;

namespace CustomerBase.UnitTests.Services.CustomerQueryServiceUnitTest;
public sealed class FindAllCustomerWithEmailAndMainTelephoneAsyncMethodUnitTest : CustomerQueryServiceSetup
{

    public static IEnumerable<object[]> CustomerDataResponseList()
    {
        yield return new object[]
        {
            new List<CustomerDataResponse>
            {
                new()
                {
                    CustomerId = 1,
                    FullName = "David Test",
                    Email = "email@test.com",
                    PhoneNumber = "+55 (18) 91172-4685"
                }, 
                new()
                {
                    CustomerId = 2,
                    FullName = "Louis Test",
                    Email = "loiusemail@test.com",
                    PhoneNumber = "+55 (18) 91172-5022"
                }, 
                new()
                {
                    CustomerId = 3,
                    FullName = "Bruna Test",
                    Email = "brunaemail@test.com",
                    PhoneNumber = "+55 (18) 91172-3326"
                },
            },

            new List<CustomerBase.API.Business.Domain.Entities.Customer>()
            {
                { CustomerBuilderTest.NewObject().WithId(1).DomainObject() },
                { CustomerBuilderTest.NewObject().WithId(2).DomainObject() },
                { CustomerBuilderTest.NewObject().WithId(3).DomainObject() }
            }
        };
    }


    [Theory]
    [Trait("Query", "Return dto CustomerDataResponse list")]
    [MemberData(nameof(CustomerDataResponseList))]
    public async Task FindAllCustomerWithEmailAndMainTelephoneAsync_ReturnCustomerDataResponseList(List<CustomerDataResponse> dtoCustomers,
                                                                                                 List<CustomerBase.API.Business.Domain.Entities.Customer> customers)
    {
        _customerRepository.Setup(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>())).ReturnsAsync(customers);
        _customerMapper.Setup(m => m.DomainToDataDtoResponse(It.IsAny<List<CustomerBase.API.Business.Domain.Entities.Customer>>())).Returns(dtoCustomers);

        var serviceResult = await _customerQueryService.FindAllCustomerWithEmailAndMainTelephoneAsync();

        Assert.NotEmpty(serviceResult);
        _customerRepository.Verify(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Once());
        _customerMapper.Verify(m => m.DomainToDataDtoResponse(It.IsAny<List<CustomerBase.API.Business.Domain.Entities.Customer>>()), Times.Once());

    }

    [Fact]
    [Trait("Query", "return empty list")]
    public async Task FindAllCustomerWithEmailAndMainTelephoneAsync_ReturnEmptyList()
    {
        var customers = new List<CustomerBase.API.Business.Domain.Entities.Customer>() { };

        _customerRepository.Setup(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>())).ReturnsAsync(customers);

        var serviceResult = await _customerQueryService.FindAllCustomerWithEmailAndMainTelephoneAsync();

        Assert.Empty(serviceResult);
        _customerRepository.Verify(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<CustomerBase.API.Business.Domain.Entities.Customer>()), Times.Once());
        _customerMapper.Verify(m => m.DomainToDataDtoResponse(It.IsAny<List<CustomerBase.API.Business.Domain.Entities.Customer>>()), Times.Never());

    }
}

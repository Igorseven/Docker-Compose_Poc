using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.ApplicationService.Services.CustomerServices;
using CustomerBase.API.Business.Domain.Interfaces.RepositoryContracts;
using Moq;

namespace CustomerBase.UnitTests.Services.CustomerQueryServiceUnitTest.Base;
public abstract class CustomerQueryServiceSetup
{
    protected readonly Mock<ICustomerRepository> _customerRepository;
    protected readonly Mock<ICustomerMapper> _customerMapper;
    protected readonly CustomerQueryService _customerQueryService;

    public CustomerQueryServiceSetup()
    {
        _customerRepository = new();
        _customerMapper = new();
        _customerQueryService = new(_customerRepository.Object,
                                    _customerMapper.Object);
    }
}

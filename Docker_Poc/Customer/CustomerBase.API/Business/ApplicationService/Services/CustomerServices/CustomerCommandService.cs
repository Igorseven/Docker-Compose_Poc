using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.ApplicationService.Interfaces.ServiceContracts;
using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
using CustomerBase.API.Business.Domain.Interfaces.RepositoryContracts;

namespace CustomerBase.API.Business.ApplicationService.Services.CustomerServices;
public sealed class CustomerCommandService : BaseService<Customer>, ICustomerCommandService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerMapper _customerMapper;

    public CustomerCommandService(INotificationHandler notification,
                                  IValidate<Customer> validate,
                                  ICustomerRepository customerRepository,
                                  ICustomerMapper customerMapper)
        : base(notification, validate)
    {
        _customerRepository = customerRepository;
        _customerMapper = customerMapper;
    }

    public void Dispose() => _customerRepository.Dispose();

    public async Task<bool> CustomerRegisterAsync(CustomerRegisterRequest dtoCustomer)
    {
        var customer = _customerMapper.DtoRegisterToDomain(dtoCustomer);

        if (!await EntityValidationAsync(customer)) return false;

        return await _customerRepository.SaveAsync(customer);
    }
}

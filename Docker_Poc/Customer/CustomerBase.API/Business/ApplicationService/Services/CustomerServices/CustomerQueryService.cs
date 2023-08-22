using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.ApplicationService.Interfaces.ServiceContracts;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.API.Business.Domain.Interfaces.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace CustomerBase.API.Business.ApplicationService.Services.CustomerServices;
public sealed class CustomerQueryService : ICustomerQueryService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerMapper _customerMapper;

    public CustomerQueryService(ICustomerRepository customerRepository,
                                ICustomerMapper customerMapper)
    {
        _customerRepository = customerRepository;
        _customerMapper = customerMapper;
    }

    public async Task<IEnumerable<CustomerDataResponse>> FindAllCustomerWithEmailAndMainTelephoneAsync()
    {
        var customers = await _customerRepository.FindAllAsync(c => c.Include(c => c.Emails.Where(e => e.EmailType == EEmailType.Main))
                                                                     .Include(c => c.Telephones));

        if (!customers.Any()) return Enumerable.Empty<CustomerDataResponse>();

        return _customerMapper.DomainToDataDtoResponse(customers);
    }

    public async Task<CustomerWithEmailAndMainAddressResponse?> FindByCustomerIdAsync(int customerId)
    {
        var customer = await _customerRepository.FindByPredicateAsync(c => c.CustomerId == customerId,
                                                                      c => c.Include(c => c.Emails.Where(e => e.EmailType == EEmailType.Main))
                                                                            .Include(c => c.Addresses.Where(a => a.AddressType == EAddressType.MainProperty)),
                                                                      true);

        if (customer is null) return null;

        return _customerMapper.DomainToEmailAndMainAddressDtoResponse(customer);
    }
}

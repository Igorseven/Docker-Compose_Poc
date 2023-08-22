using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.API.Business.Domain.Extensions;

namespace CustomerBase.API.Business.ApplicationService.Mappers;
public sealed class CustomerMapper : ICustomerMapper
{
    private readonly IAddressMapper _addressMapper;
    private readonly IEmailAddressMapper _emailAddressMapper;
    private readonly ITelephoneMapper _telephoneMapper;

    public CustomerMapper(IAddressMapper addressMapper,
                          IEmailAddressMapper emailAddressMapper,
                          ITelephoneMapper telephoneMapper)
    {
        _addressMapper = addressMapper;
        _emailAddressMapper = emailAddressMapper;
        _telephoneMapper = telephoneMapper;
    }

    public Customer DtoRegisterToDomain(CustomerRegisterRequest dtoCustomer) =>
        new()
        {
            FullName = dtoCustomer.FullName,
            Addresses = _addressMapper.DtoRegisterToDomain(dtoCustomer.Addresses),
            Emails = _emailAddressMapper.DtoRegisterToDomain(dtoCustomer.Emails),
            Telephones = _telephoneMapper.DtoRegisterToDomain(dtoCustomer.Phones)
        };


    public CustomerDataResponse DomainToDataDtoResponse(Customer customer)
    {
        var phone = customer.Telephones.FirstOrDefault();
        var emailAddress = customer.Emails.FirstOrDefault();

        return new()
        {
            CustomerId = customer.CustomerId,
            FullName = customer.FullName,
            Email = emailAddress!.Email,
            PhoneNumber = phone!.PhoneNumberMask()
        };
    }

    public List<CustomerDataResponse> DomainToDataDtoResponse(List<Customer> customers)
    {
        List<CustomerDataResponse> dtoCustomers = new();

        foreach (var customer in customers)
        {
            var dtoCustomer = DomainToDataDtoResponse(customer); 
            
            dtoCustomers.Add(dtoCustomer);
        }

        return dtoCustomers;
    }



    public CustomerWithEmailAndMainAddressResponse DomainToEmailAndMainAddressDtoResponse(Customer customer)
    {
        var mainAddress = customer.Addresses.FirstOrDefault(a => a.AddressType == EAddressType.MainProperty);
        var mainEmail = customer.Emails.FirstOrDefault(e => e.EmailType == EEmailType.Main);

        return new()
        {
            CustomerId = customer.CustomerId,
            FullName = customer.FullName,
            Email = mainEmail!.Email,
            Address = _addressMapper.DomainToCustomerDtoResponse(mainAddress!)
        };
    }
}

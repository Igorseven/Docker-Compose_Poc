using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.ApplicationService.Mappers;
using Moq;

namespace CustomerBase.UnitTests.Mappers.CustomerMappers.Base;
public abstract class CustomerMapperSetup 
{
    protected readonly Mock<IAddressMapper> _addressMapper;
    protected readonly Mock<IEmailAddressMapper> _emailAddressMapper;
    protected readonly Mock<ITelephoneMapper> _telephoneMapper;
    protected readonly CustomerMapper _customerMapper;

    public CustomerMapperSetup()
    {
        _addressMapper = new();
        _emailAddressMapper = new();
        _telephoneMapper = new();
        _customerMapper = new(_addressMapper.Object,
                              _emailAddressMapper.Object,
                              _telephoneMapper.Object);
    }
}

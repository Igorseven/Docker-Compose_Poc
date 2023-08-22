using CustomerBase.API.Business.ApplicationService.Mappers;

namespace CustomerBase.UnitTests.Mappers.AddressMappers.Base;
public abstract class AddressMapperSetup
{
    protected readonly AddressMapper _addressMapper;

    public AddressMapperSetup()
    {
        _addressMapper = new();
    }
}

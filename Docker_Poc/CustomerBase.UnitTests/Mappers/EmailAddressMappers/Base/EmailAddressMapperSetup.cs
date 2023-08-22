using CustomerBase.API.Business.ApplicationService.Mappers;

namespace CustomerBase.UnitTests.Mappers.EmailAddressMappers.Base;
public abstract class EmailAddressMapperSetup
{
    protected readonly EmailAddressMapper _emailAddressMapper;

    public EmailAddressMapperSetup()
    {
        _emailAddressMapper = new();
    }
}

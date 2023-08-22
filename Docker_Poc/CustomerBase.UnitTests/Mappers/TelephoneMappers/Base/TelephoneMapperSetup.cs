using CustomerBase.API.Business.ApplicationService.Mappers;

namespace CustomerBase.UnitTests.Mappers.TelephoneMappers.Base;
public abstract class TelephoneMapperSetup
{
    protected readonly TelephoneMapper _telephoneMapper;

    public TelephoneMapperSetup()
    {
        _telephoneMapper = new();
    }
}

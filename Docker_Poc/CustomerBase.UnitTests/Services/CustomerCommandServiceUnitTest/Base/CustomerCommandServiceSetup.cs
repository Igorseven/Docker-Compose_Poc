using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.ApplicationService.Services.CustomerServices;
using CustomerBase.API.Business.Domain.Handlers.ValidationHandler;
using CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
using CustomerBase.API.Business.Domain.Interfaces.RepositoryContracts;
using Moq;

namespace CustomerBase.UnitTests.Services.CustomerCommandServiceUnitTest.Base;
public abstract class CustomerCommandServiceSetup
{
    protected readonly Mock<INotificationHandler> _notification;
    protected readonly Mock<IValidate<CustomerBase.API.Business.Domain.Entities.Customer>> _validate;
    protected readonly Mock<ICustomerRepository> _customerRepository;
    protected readonly Mock<ICustomerMapper> _customerMapper;
    protected readonly ValidationResponse _validationResponse;
    protected readonly CustomerCommandService _customerCommandService;
    private readonly Dictionary<string, string> _errors;

    public CustomerCommandServiceSetup()
    {
        _notification = new();
        _validate = new();
        _customerRepository = new();
        _customerMapper = new();
        _errors = new();
        _validationResponse = ValidationResponse.CreateResponse(_errors);
        _customerCommandService = new(_notification.Object,
                                      _validate.Object,
                                      _customerRepository.Object,
                                      _customerMapper.Object);
    }

    protected void CreateInvalidDataNotification() =>
        _errors.Add("Error", "Error"); 
}

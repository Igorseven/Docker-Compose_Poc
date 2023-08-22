using CustomerBase.API.Business.Domain.Handlers.NotificationHandler;

namespace CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
public interface INotificationHandler
{
    bool CreateNotification(string key, string value);
    void CreateNotification(DomainNotification notification);
    void CreateNotifications(IEnumerable<DomainNotification> notifications);
    bool HasNotification();
    List<DomainNotification> GetNotifications();
}

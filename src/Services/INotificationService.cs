namespace Manga;

public interface INotificationService
{
    public Task<HttpResponseMessage> Send(Notification notification);
    public Task<List<HttpResponseMessage>> Send(IEnumerable<Notification> notifications);
}
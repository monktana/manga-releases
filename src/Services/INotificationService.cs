using MangaReleases.Models;

namespace MangaReleases.Services;

public interface INotificationService
{
    public Task<HttpResponseMessage> Send(Notification notification);
    public Task<List<HttpResponseMessage>> Send(IEnumerable<Notification> notifications);
}
using System.Text;
using System.Text.Json;
using MangaReleases.Models;

namespace MangaReleases.Services;

public class DiscordNotificationService(HttpClient client) : INotificationService
{
    public async Task<HttpResponseMessage> Send(Notification notification)
    {
        var serialized = JsonSerializer.Serialize(notification);
        var content = new StringContent(serialized, Encoding.UTF8, "application/json");

        return await client.PostAsync(
            "",
            content
        );
    }

    public async Task<List<HttpResponseMessage>> Send(IEnumerable<Notification> notifications)
    {
        return (await Task.WhenAll(notifications.Select(Send))).ToList();
    }
}
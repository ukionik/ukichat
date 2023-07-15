using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using UkiChat.Tests.Core;

namespace UkiChat.Tests.Tests.Chat;

public class TwitchChatTest : BaseTest
{
    private TwitchClient? _client;

    [SetUp]
    public void Setup()
    {
        _client = new TwitchClient();
        var credentials = new ConnectionCredentials(AppConfig.settings.twitch.userName, AppConfig.settings.twitch.accessToken);
        var clientOptions = new ClientOptions
        {
            MessagesAllowedInPeriod = 750,
            ThrottlingPeriod = TimeSpan.FromSeconds(30)
        };
        var customClient = new WebSocketClient(clientOptions);
        _client = new TwitchClient(customClient);
        _client.Initialize(credentials, AppConfig.settings.twitch.channel);

        _client.OnLog += Client_OnLog;
        _client.OnJoinedChannel += Client_OnJoinedChannel;
        _client.OnMessageReceived += Client_OnMessageReceived;
        _client.OnWhisperReceived += Client_OnWhisperReceived;
        _client.OnNewSubscriber += Client_OnNewSubscriber;
        _client.OnConnected += Client_OnConnected;
    }

    private void Client_OnConnected(object? sender, OnConnectedArgs e)
    {
        Console.WriteLine("[Connected]");
    }

    private void Client_OnNewSubscriber(object? sender, OnNewSubscriberArgs e)
    {
    }

    private void Client_OnWhisperReceived(object? sender, OnWhisperReceivedArgs e)
    {
    }

    private void Client_OnMessageReceived(object? sender, OnMessageReceivedArgs e)
    {
        Console.WriteLine($"[Message] {e.ChatMessage}");
    }

    private void Client_OnJoinedChannel(object? sender, OnJoinedChannelArgs e)
    {
        Console.WriteLine($"[Joined Channel] {e.Channel}");
    }

    private void Client_OnLog(object? sender, OnLogArgs e)
    {
        Console.WriteLine($"[Log] {e.Data}");
    }

    [Test]
    public async Task ConnectTest()
    {
        _client.Connect();
        await Task.Delay(10 * 60 * 1000);
    }
}
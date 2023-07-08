using System.Windows;
using GenHTTP.Engine;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Security;
using GenHTTP.Modules.StaticWebsites;
using Microsoft.Extensions.DependencyInjection;
using UkiChat.Configuration;
using UkiChat.Extensions;
using UkiChat.Service;

namespace UkiChat;

public partial class App
{
    private readonly ServiceProvider _diProvider;

    public App()
    {
        _diProvider = DIConfig.Init();

        var tree = ResourceTree.FromDirectory("wwwroot/");

        var resourceTree = ResourceTree.FromDirectory("Resources/");

        var app = Layout.Create()
            .Add("resources", GenHTTP.Modules.IO.Resources.From(resourceTree))
            .AddControllers(_diProvider)
            .Add(CorsPolicy.Permissive())
            .Add(StaticWebsite.From(tree));

        Host.Create()
            .Handler(app)
            .Defaults()
            .Port(18588)
            .Start();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        InitApp();
    }

    private void InitApp()
    {
        _diProvider.GetService<IAppInitializationService>().Init();
    }
}
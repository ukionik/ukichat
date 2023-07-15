using Newtonsoft.Json;
using UkiChat.Data.AppConfiguration;
using UkiChat.Repository;

namespace UkiChat.Tests.Repository;

public class AppConfigRepositoryTest : IAppConfigRepository
{
    private readonly IConfigurationRepository _configurationRepository;

    public AppConfigRepositoryTest(IConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public AppConfig Data { get; private set; }

    public void Load()
    {
        var appConfigPath = Path.Combine(_configurationRepository.AppPath, "app-config.test.json");
        var json = File.ReadAllText(appConfigPath);
        Data = JsonConvert.DeserializeObject<AppConfig>(json);
    }
}
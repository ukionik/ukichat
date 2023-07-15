using UkiChat.Data.AppConfiguration;
using UkiChat.Repository;
using UkiChat.Tests.Repository;

namespace UkiChat.Tests.Core;

public abstract class BaseTest
{
    private readonly IAppConfigRepository _appConfigRepository;
    protected AppConfig AppConfig => _appConfigRepository.Data;
    
    protected BaseTest()
    {
        Console.SetOut(TestContext.Progress);
        _appConfigRepository = new AppConfigRepositoryTest(new ConfigurationRepositoryTest());
        _appConfigRepository.Load();
    }
}
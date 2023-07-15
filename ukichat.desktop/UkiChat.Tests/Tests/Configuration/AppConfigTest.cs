using UkiChat.Tests.Core;
using UkiChat.Tests.Repository;

namespace UkiChat.Tests.Tests.Configuration;

public class AppConfigTest : BaseTest
{
    private AppConfigRepositoryTest _appConfigRepository;

    [SetUp]
    public void Setup()
    {
        _appConfigRepository = new AppConfigRepositoryTest(new ConfigurationRepositoryTest());
    }

    [Test]
    public void LoadConfigTest()
    {
        _appConfigRepository.Load();
        Console.WriteLine(_appConfigRepository.Data);
    }
}
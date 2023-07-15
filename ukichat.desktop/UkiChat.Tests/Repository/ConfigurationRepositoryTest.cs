using UkiChat.Repository;

namespace UkiChat.Tests.Repository;

public class ConfigurationRepositoryTest : IConfigurationRepository
{
    public string AppPath { get; set; } = Directory.GetParent(typeof(ConfigurationRepository).Assembly.Location).FullName;
}
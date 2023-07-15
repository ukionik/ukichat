using System.IO;
using UkiChat.Core;

namespace UkiChat.Repository;

[Repository]
public class ConfigurationRepository : IConfigurationRepository
{
    public string AppPath { get; private set; } = Directory.GetParent(typeof(ConfigurationRepository).Assembly.Location).FullName;
}
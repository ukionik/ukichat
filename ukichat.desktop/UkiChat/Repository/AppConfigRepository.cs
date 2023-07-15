using System;
using UkiChat.Core;
using UkiChat.Data.AppConfiguration;

namespace UkiChat.Repository;

[Repository]
public class AppConfigRepository : IAppConfigRepository
{
    public AppConfig Data { get; private set; }
    
    public void Load()
    {
        throw new NotImplementedException();
    }
}
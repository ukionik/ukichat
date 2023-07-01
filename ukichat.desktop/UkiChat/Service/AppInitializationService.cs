using System.Linq;
using Microsoft.EntityFrameworkCore;
using UkiChat.Configuration;
using UkiChat.Core;
using UkiChat.Data;

namespace UkiChat.Service;

[Service]
public class AppInitializationService : IAppInitializationService
{
    private readonly AppDbContext _dbContext;

    public AppInitializationService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Init()
    {
        _dbContext.Database.Migrate();
        CreateOrUpdateAppVersion();
    }
    
    private void CreateOrUpdateAppVersion()
    {
        var app = _dbContext.App.FirstOrDefault();

        if (app == null)
        {
            app = new Entity.App
            {
                Version = AppData.VersionLong
            };
            _dbContext.App.Add(app);
        }
        else if (app.Version != AppData.VersionLong)
        {
            app.Version = AppData.VersionLong;
        }

        _dbContext.SaveChanges();
    }
}
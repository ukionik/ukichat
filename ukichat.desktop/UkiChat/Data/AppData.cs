using System.Reflection;
using Microsoft.Extensions.Logging;
using UkiChat.Extensions;

namespace UkiChat.Data;

public static class AppData
{
    public static string Version { get; }
    public static long VersionLong { get; }
    
    private static bool IsDebug { get; }
    
    static AppData()
    {
        var v = Assembly.GetExecutingAssembly().GetName().Version;

        Version = v.ShortName();
        VersionLong = v.ToLong(parts: 3);

        IsDebug = false;

#if DEBUG
        IsDebug = true;
#endif

    }
}
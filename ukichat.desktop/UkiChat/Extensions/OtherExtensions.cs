using System;

namespace UkiChat.Extensions;

public static class OtherExtensions
{
    public static string ShortName(this Version version)
    {
        return $"{version.Major}.{version.Minor}.{version.Build}";
    }

    public static long ToLong(this Version version, int digits = 3, int parts = 4)
    {
        return parts switch
        {
            1 => version.Major,
            2 => version.Major * (long)Math.Pow(10.0, digits) + version.Minor,
            3 => version.Major * (long)Math.Pow(10.0, digits * 2) +
                 version.Minor * (long)Math.Pow(10.0, digits) + version.Build,
            _ => version.Major * (long)Math.Pow(10.0, digits * 3) +
                 version.Minor * (long)Math.Pow(10.0, digits * 2) +
                 version.Build * (long)Math.Pow(10.0, digits) + version.Revision
        };
    }
}
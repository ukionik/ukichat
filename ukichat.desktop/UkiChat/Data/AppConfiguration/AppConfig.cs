using Newtonsoft.Json;

namespace UkiChat.Data.AppConfiguration;

public record AppConfig(AppSettings settings)
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
};
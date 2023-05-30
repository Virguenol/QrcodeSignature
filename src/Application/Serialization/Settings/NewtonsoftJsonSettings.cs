
using Grs.BioRestock.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace Grs.BioRestock.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}
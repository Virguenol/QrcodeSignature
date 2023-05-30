using System.Text.Json;
using Grs.BioRestock.Application.Interfaces.Serialization.Serializers;
using Grs.BioRestock.Application.Serialization.Options;
using Microsoft.Extensions.Options;

namespace Grs.BioRestock.Application.Serialization.Serializers
{
    public class SystemTextJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerOptions _options;

        public SystemTextJsonSerializer(IOptions<SystemTextJsonOptions> options)
        {
            _options = options.Value.JsonSerializerOptions;
        }

        public T Deserialize<T>(string data)
            => JsonSerializer.Deserialize<T>(data, _options);

        public string Serialize<T>(T data)
            => JsonSerializer.Serialize(data, _options);
    }
}
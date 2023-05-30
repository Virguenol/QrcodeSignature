using System.Text.Json;
using Grs.BioRestock.Application.Interfaces.Serialization.Options;

namespace Grs.BioRestock.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}
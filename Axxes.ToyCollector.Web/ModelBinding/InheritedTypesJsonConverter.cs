using System;
using Axxes.ToyCollector.DependencyResolution;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Axxes.ToyCollector.Web.ModelBinding
{
    public class InheritedTypesJsonConverter : JsonConverter
    {
        private const string TypePropertyName = "$type";
        private readonly InheritedTypesRegistry _inheritedTypesRegistry;

        public InheritedTypesJsonConverter(InheritedTypesRegistry inheritedTypesRegistry)
        {
            _inheritedTypesRegistry = inheritedTypesRegistry;
        }
        
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return _inheritedTypesRegistry.CanConvert(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);

            var typeName = jObject[TypePropertyName]?.Value<string>();

            var target = _inheritedTypesRegistry.CreateType(objectType, typeName);

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
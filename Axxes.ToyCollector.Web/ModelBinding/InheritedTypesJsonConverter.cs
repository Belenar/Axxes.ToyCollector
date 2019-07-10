using System;
using Axxes.ToyCollector.DependencyResolution;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Axxes.ToyCollector.Web.ModelBinding
{
    public class InheritedTypesJsonConverter : JsonConverter
    {
        private const string TypePropertyName = "$type";
        private readonly InheritedTypesRegistry _typesRegistry;

        public InheritedTypesJsonConverter(InheritedTypesRegistry typesRegistry)
        {
            _typesRegistry = typesRegistry;
        }
        
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return _typesRegistry.CanConvert(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (serializer == null) throw new ArgumentNullException(nameof(serializer));
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);

            var typeName = jObject[TypePropertyName]?.Value<string>();

            var target = _typesRegistry.CreateType(objectType, typeName);

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
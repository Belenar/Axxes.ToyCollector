using System;
using System.Collections.Generic;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution;

namespace Axxes.ToyCollector.DependencyResolution
{
    public class InheritedTypesRegistry : IInheritedTypesRegistry
    {
        private readonly Dictionary<Type, Dictionary<string, Func<object>>> _registrations 
            = new Dictionary<Type, Dictionary<string, Func<object>>>();

        void IInheritedTypesRegistry.RegisterInheritedType<TParentType, TChildType>(string typeName)
        {
            var parentType = typeof(TParentType);

            if (!_registrations.ContainsKey(parentType))
            {
                _registrations[parentType] = new Dictionary<string, Func<object>>();
                _registrations[parentType][string.Empty] = () => new TParentType();
            }

            _registrations[parentType][typeName] = () => new TChildType();
        }

        public bool CanConvert(Type objectType)
        {
            return _registrations.ContainsKey(objectType);
        }

        public object CreateType(Type objectType, string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return _registrations[objectType][string.Empty]();

            if(!_registrations[objectType].ContainsKey(typeName))
                return _registrations[objectType][string.Empty]();

            return _registrations[objectType][typeName]();
        }
    }
}

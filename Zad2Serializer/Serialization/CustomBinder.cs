using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Zad2Serializer.Serialization
{
    class CustomBinder : SerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = serializedType.Assembly.FullName;
            typeName = serializedType.FullName;
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            return assembly.GetType(typeName);
        }
    }
}

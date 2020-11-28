using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Zad2Serializer.Serialization
{
    class DesObjectInfo
    {
        public Type Type { get; set;}
        public string Name { get; set;}
        public long RefId{ get; set;}
        public SerializationInfo SerializationInfo { get; set;}

        public DesObjectInfo(Type type, string name, long refId, SerializationInfo serializationInfo)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            RefId = refId;
            SerializationInfo = serializationInfo ?? throw new ArgumentNullException(nameof(serializationInfo));
        }
    }
}

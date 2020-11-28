using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Zad2Serializer.Serialization
{
    class CustomFormatter : Formatter
    {
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        public override ISurrogateSelector SurrogateSelector { get; set; }

        private string Data = "";

        public CustomFormatter()
        {
            Binder = new CustomBinder();
            Context = new StreamingContext(StreamingContextStates.File);
        }

        public override object Deserialize(Stream serializationStream)
        {
            object desObject = null;
            Dictionary<long, DesObjectInfo> refObjectInfos = new Dictionary<long, DesObjectInfo>();
            Dictionary<long, object> desObjects = new Dictionary<long, object>();

            using (StreamReader reader = new StreamReader(serializationStream))
            {
                while (!reader.EndOfStream) 
                {
                    string header = reader.ReadLine().Remove(0, 1);
                    header = header.Remove(header.Length - 1);
                    string[] hvals = header.Split('|');

                    Type objectType = Binder.BindToType(hvals[0], hvals[1]);
                    long id = long.Parse(hvals[2]);

                    SerializationInfo serializationInfo = new SerializationInfo(objectType, new FormatterConverter());
                    object obj = FormatterServices.GetUninitializedObject(objectType);

                    desObjects.Add(id, obj);

                    if (desObject == null)
                    {
                        desObject = obj;
                    }

                    string body = reader.ReadLine();
                    string[] bvals = body.Split(new char[] { '[', ']' } , StringSplitOptions.RemoveEmptyEntries);

                    foreach (string field in bvals)
                    {
                        string[] elements = field.Split('|');
                        string tType = elements[0];
                        string tName = elements[1];
                        string tValue = elements[2];

                        if (tValue.Contains("ref"))
                        {
                            long idref = Convert.ToInt64(tValue.Remove(0, 3));
                            refObjectInfos.Add(id, new DesObjectInfo(Type.GetType(tType), tName, idref, serializationInfo));
                        }
                        else if (tValue.Contains("null"))
                        {
                            Type type = Type.GetType(tType);
                            serializationInfo.AddValue(tName, null, type);
                        }
                        else
                        {
                            Type type = Type.GetType(tType);
                            serializationInfo.AddValue(tName, Convert.ChangeType(tValue, type, CultureInfo.InvariantCulture), type);
                        }
                    }
                }
            }

            foreach (var refInfo in refObjectInfos)
            {
                var refInfoV = refInfo.Value;
                refInfoV.SerializationInfo.AddValue(refInfoV.Name, desObjects[refInfoV.RefId], refInfoV.Type);
            }

            for (long i = 1; i < desObjects.Count + 1; i++)
            {
                var constructor = desObjects[i].GetType().GetConstructor(new Type[] { typeof(SerializationInfo), typeof(StreamingContext) });
                constructor.Invoke(desObjects[i], new object[] { refObjectInfos[i].SerializationInfo, Context});
            }

            return desObject;
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable data)
            {
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);

                Data += "{" + assemblyName + "|" + typeName + "|" + m_idGenerator.GetId(graph, out bool firstTime) + "}"+"\n";
                data.GetObjectData(info, Context);

                foreach (SerializationEntry item in info)
                {
                    WriteMember(item.Name, item.Value);
                }
                Data += "\n";
                while (m_objectQueue.Count != 0)
                {
                    Serialize(null, m_objectQueue.Dequeue());
                }

                if (serializationStream != null)
                {


                    using (StreamWriter writer = new StreamWriter(serializationStream))
                    {
                        writer.Write(Data);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Cannot serialize provided object.");
            }
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            Data += "[" + val.GetType() + "|" + name + "|" + val.ToString("d", DateTimeFormatInfo.InvariantInfo) + "]";
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            Data += "[" + val.GetType() + "|" + name + "|" + val.ToString(CultureInfo.InvariantCulture) + "]";
        }

        protected override void WriteInt64(long val, string name)
        {
            Data += "[" + val.GetType() + "|" + name + "|" + val.ToString(CultureInfo.InvariantCulture) + "]";
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String)))
            {
                Data += "[" + obj.GetType() + "|" + name + "|" + (string)obj + "]";
            }
            else
            {
                if (null != obj)
                {
                    Data += "[" + obj.GetType() + "|" + name + "|ref" + m_idGenerator.GetId(obj, out bool firstTime).ToString() + "]";
                    if (firstTime)
                    {
                        m_objectQueue.Enqueue(obj);
                    }
                }
                else
                {
                    Data += "[" + obj.GetType() + "|" + name + "|" + "null" + "]";
                }
            }

        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            Data += "[" + val.GetType() + "|" + name + "|" + val.ToString(CultureInfo.InvariantCulture) + "]";
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;

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
            throw new NotImplementedException();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            throw new NotImplementedException();
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
                    Data += "[" + "null" + "|" + name + "]";
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

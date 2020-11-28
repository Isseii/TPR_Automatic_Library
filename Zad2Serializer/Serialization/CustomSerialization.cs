using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Zad2Serializer.Serialization
{
    public class CustomSerialization<T>
    {
        private String FileName;
        private T ObjectToSerialize;
        private CustomFormatter Formatter;

        public CustomSerialization(string file, T objectToSerialize)
        {
            FileName = file;
            ObjectToSerialize = objectToSerialize;
            Formatter = new CustomFormatter();
        }


        public void serialize()
        {
            File.Delete(FileName);
            using (Stream stream = File.Open(this.FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                Formatter.Serialize(stream, this.ObjectToSerialize);
            }

        }
    }
}

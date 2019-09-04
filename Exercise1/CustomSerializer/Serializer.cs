using System.IO;
using System;
namespace Exercise1.CustomSerializer
{
    internal class Serializer
    {
        private ICustomSerializable serializer;
        private Contact contact;
        public Serializer( Contact contact)
        {
            this.contact = contact;
        }
        public void Serialize(OutputFormat outputFormat)
        {
            if (outputFormat == OutputFormat.Xml)
                this.serializer = new SerializerToXml();
           else if (outputFormat == OutputFormat.Csv)
                this.serializer = new SerializerToCsv();
            else
                throw new ArgumentOutOfRangeException();
            using (StreamWriter writer = new StreamWriter("file."+serializer.Extend, false))
            {
                serializer.Serialize(writer, contact);
            }
        }
    }
}

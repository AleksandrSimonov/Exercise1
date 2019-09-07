using System;
using System.IO;
namespace Contact.CustomSerializer
{
    public class Serializer
    {
        private Contact _contact;
        private string _path = "file";
        public Serializer(Contact contact)
        {
            _contact = contact;
        }
        public void Serialize(OutputFormat outputFormat)
        {
            ICustomSerializable serializer;
            if (outputFormat == OutputFormat.Xml)
                serializer = new SerializerToXml();
            else if (outputFormat == OutputFormat.Csv)
                serializer = new SerializerToCsv();
            else
                throw new ArgumentOutOfRangeException();

            using (StreamWriter writer = new StreamWriter(_path+"." + serializer.Extension, false))
            {
                serializer.Serialize(writer, _contact);
            }
        }
        public void Serialize(string path, OutputFormat outputFormat)
        {
            _path = path;
            Serialize(outputFormat);
        }
    }
}

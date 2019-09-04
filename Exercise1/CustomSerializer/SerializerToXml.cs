using System;
using System.IO;
using System.Xml.Serialization;

namespace Exercise1.CustomSerializer
{
    internal class SerializerToXml : ICustomSerializable
    {
        public string Extend
        {
            get
            {
                return "xml";
            }
        }
        public void Serialize(StreamWriter output, object obj)
        {
            if ((output == null) || (obj == null))
                throw new ArgumentNullException();

            XmlSerializer formatter = new XmlSerializer(obj.GetType());
            formatter.Serialize(output, obj);

        }
    }
}

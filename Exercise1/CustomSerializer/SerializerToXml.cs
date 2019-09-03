using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;
using Exercise1.CustomSerializer;

namespace Exercise1.CustomSerializer
{
    class SerializerToXml: ICustomSerializable
    {
        public void Serialize(StreamWriter output, object obj)
        {
            if ((output == null) || (obj == null))
                throw new ArgumentNullException();

            XmlSerializer formatter = new XmlSerializer(obj.GetType());
            formatter.Serialize(output, obj);

        }
    }
}

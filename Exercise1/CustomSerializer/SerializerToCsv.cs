using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise1.CustomSerializer;
using System.Xml.Serialization;
using System.Reflection;
namespace Exercise1.CustomSerializer
{
   class SerializerToCsv : ICustomSerializable
    {
        public  void Serialize(StreamWriter output, object obj)
        {
            if ((output == null)||(obj==null))
                throw new ArgumentNullException();

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            var csvName = new StringBuilder();
            var csvValue = new StringBuilder();

            // First line contains field names
            foreach (PropertyInfo prp in properties)
            {
                if (prp.CanRead)
                {
                    csvName.Append(prp.Name).Append(';');
                    csvValue.Append(prp.GetValue(obj,null)).Append(';');
                }
            }
            csvName.Length--; // Remove last ";"
            csvValue.Length--;

            //after your loop
            output.WriteLine(csvName);
            output.WriteLine(csvValue);

        }

    }
}

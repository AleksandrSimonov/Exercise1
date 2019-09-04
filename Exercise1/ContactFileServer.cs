using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Exercise1.CustomSerializer;
namespace Exercise1
{
    class ContactFileServer : IDisposable
    {
        StreamWriter streamWriter;
        bool isDispose = true;
        public ContactFileServer()
        {
            streamWriter = new StreamWriter("file.csv", false, Encoding.UTF8);
            isDispose = false;
        }
        public void Save(Contact person)
        {
            var serealizer = new SerializerToCsv();
            serealizer.Serialize(streamWriter, person);
            Dispose();

        }
        public void Dispose()
        {
            if (!isDispose)
                streamWriter.Dispose();
        }
    }
}

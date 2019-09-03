using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Exercise1.CustomSerializer;
namespace Exercise1
{
   public interface ICustomSerializable
    {
        void Serialize(StreamWriter output, Object obj);
    }
}

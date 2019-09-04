using System;
using System.IO;
namespace Exercise1
{
    public interface ICustomSerializable
    {
        void Serialize(StreamWriter output, Object obj);
        string Extend { get; }
    }
}

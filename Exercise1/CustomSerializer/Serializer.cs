﻿using System;
using System.IO;
namespace Exercise1.CustomSerializer
{
    public class Serializer
    {
        private Contact _contact;
        public Serializer(Contact contact)
        {
            this._contact = contact;
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

            using (StreamWriter writer = new StreamWriter("file." + serializer.Extension, false))
            {
                serializer.Serialize(writer, _contact);
            }
        }
    }
}

﻿using Exercise1.Attributes;
using System;
using System.IO;
using System.Runtime.Serialization;
using Exercise1.CustomSerializer;
namespace Exercise1
{
    [Serializable]
    [TypeDescription("Person")]
    public sealed class Contact : ICloneable
    {

        [MaxLength(15)]
        public string Name { get; set; }


        [MaxLength(15)]
        public string Surname { get; set; }


        [MaxLength(15)]
        public string LastName { get; set; }

        public SexEnum Sex { get; }

        [RegularExpression(@"^\s *\+?\s * ([0 - 9][\s -] *){9,}$")]
        public string PhoneNumber { get; set; }

        [MinBirthday(1980, 1, 1)]
        public DateTime Birthday { get; }

        public double TaxId { get; set; }

        public string Post { get; set; }

        public Organization Job { get; set; }

        public Contact(string name, string surname, string lastname, SexEnum sex,
            string phoneNumber, DateTime birthday, double taxId, string post, Organization job)
        {
            Name = name;
            Surname = surname;
            LastName = lastname;
            Sex = sex;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            TaxId = taxId;
            Post = post;
            Job = job;
        }

        public Contact(string name, string surname, string lastname, SexEnum sex,
            DateTime birthday)
        {
            Name = name;
            Surname = surname;
            LastName = lastname;
            Sex = sex;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return Surname + " " + Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Contact == false)
                return false;
            return this.TaxId.Equals(((Contact) obj).TaxId);
        }

        public override int GetHashCode()
        {
            return this.TaxId.GetHashCode();
        }

        public object Clone()
        {
            return ((Contact)this.MemberwiseClone()).
                Job =new Organization(this.Job.Name, 
                this.Job.PhoneNumber);
            
        }

        private void Save(IFormatter formatter)
        {
            if (formatter == null)
                throw new NullReferenceException();
            using (FileStream fs = new FileStream("contact.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Сериализация начата");
                formatter.Serialize(fs, this);
                Console.WriteLine("Сериализация закончена");
            }
        }

        public void SerializeToXml(Stream output, object obj)
        {
            
        }

        public void SerializeToCsv(Stream output, object obj)
        {
            throw new NotImplementedException();
        }
    }
}

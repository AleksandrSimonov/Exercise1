using Exercise1.Attributes;
using System;
using System.Text.RegularExpressions;
using Exercise1.CustomSerializer;
using System.IO;
namespace Exercise1
{
    internal class Program
    {

        internal static void Main(string[] args)
        {

            var contact = new Contact("Aleksandr", "Simonov", "Vladimirovich",
                SexEnum.Male, "+7 (904) 672 53 74", new DateTime(1996, 9, 24), 3657878675352, "trainee",
                new Organization("Navicon", "+7 (917) 295 99 46"));

            var type = typeof(Contact);
            Console.Write("Корректное имя: ");
            Console.WriteLine(Convert.ToBoolean(((MaxLengthAttribute) type.GetProperty("Name").GetCustomAttributes(typeof(MaxLengthAttribute), false)[0]).MaxLength.CompareTo(contact.Name.Length)));
            Console.Write("Корректная фамилия: ");
            Console.WriteLine(Convert.ToBoolean(((MaxLengthAttribute) type.GetProperty("Surname").GetCustomAttributes(false)[0]).MaxLength.CompareTo(contact.Surname.Length)));
            Console.Write("Корректное отчество: ");
            Console.WriteLine(Convert.ToBoolean(((MaxLengthAttribute) type.GetProperty("Surname").GetCustomAttributes(false)[0]).MaxLength.CompareTo(contact.LastName.Length)));

            Console.Write("Корректный возраст: ");
            var minBirthdayAttribute = (MinBirthdayAttribute) type.GetProperty("Birthday").GetCustomAttributes(false)[0];
            var birthday = new DateTime(minBirthdayAttribute.MinYear, minBirthdayAttribute.MinMonth, minBirthdayAttribute.MinDay);
            Console.WriteLine(Convert.ToBoolean(contact.Birthday.CompareTo(birthday)));

            Console.Write("Корректный номер: ");
            var regex = new Regex(((RegularExpressionAttribute) typeof(Contact).GetProperty("PhoneNumber").GetCustomAttributes(false)[0]).RegularExpression);
            Console.WriteLine(regex.IsMatch(contact.PhoneNumber));

            Console.WriteLine("как сохранить?\n" +
                "1. в CSV\n" +
                "2. в XMl");

            if(int.TryParse(Console.ReadLine(), out int result))
                switch (result)
                {
                    case 1:
                        using (StreamWriter writer = new StreamWriter("file.csv", false))
                        {
                            var ser = new SerializerToCsv();
                            ser.Serialize(writer, contact);
                        }
                        break;
                    case 2:
                        using (StreamWriter writer = new StreamWriter("file.xml", false))
                        {
                            var ser = new SerializerToXml();
                            ser.Serialize(writer, contact);
                        }
                        break;
                }
               
                Console.ReadKey();
        }
    }
}

using Exercise1.CustomSerializer;
using System;
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

            var contactValidate = new Validate(contact);
            contactValidate.DoValidate();


            Console.WriteLine("как сохранить?\n" +
                "1. в XMl\n" +
                "2. в CSV");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                var serializer = new Serializer(contact);
                serializer.Serialize((OutputFormat) result-1);
                Console.WriteLine("Объект " + contact.GetType() + " сериализован");
            }
            else
                Console.WriteLine("Неправильный вариант!");

            var cfs = new ContactFileServer();
            cfs.Save(contact);
            cfs.Dispose();

            Console.WriteLine("Для закрытия приложения нажмите любую клавишу\n(кроме выключения!!!!)");
            Console.ReadKey();
        }
    }
}

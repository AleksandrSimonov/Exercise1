using Contact;
using Contact.ContactTest;
using Contact.ContactValidation;
using Contact.CustomSerializer;
using System;
namespace Exercise1
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            //1.1

            var contact = new Contact.Contact("Aleksandr", "Simonov", "Vladimirovich",
                SexEnum.Male, "+7 (904) 672 53 74", new DateTime(1996, 9, 24), 3657878675352, "trainee",
                new Organization("Navicon", "+7 (917) 295 99 46"));

            var contactValidate = new ContactValidater(contact);
            var resultValidate = contactValidate.Validate();
            Console.WriteLine(resultValidate);

            //1.3

            var cfs = new ContactFileSaver();
            cfs.Save(contact);
            cfs.Dispose();

            //2
            Console.WriteLine("как сохранить?\n" +
                "1. в XMl\n" +
                "2. в CSV");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                var contactTest = new RandomContact();
                Serializer serializer;
                for (int i = 0; i < 3; i++)
                {
                    contact = contactTest.NextFullContact();

                    Console.WriteLine("Начало выгрузки контакта №" + i + 1);
                    serializer = new Serializer(contact);
                    try
                    {
                        serializer.Serialize((OutputFormat) result);
                        Console.WriteLine("Объект " + contact.GetType() + " сериализован");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Введен неверный формат сериализации");
                    }
                }
            }





            Console.WriteLine("Для закрытия приложения нажмите любую клавишу\n(кроме выключения!!!!)");
            Console.ReadKey();
        }
    }
}

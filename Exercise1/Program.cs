using Contact;
using Contact.ContactTest;
using Contact.ContactValidation;
using Contact.CustomSerializer;
using System;
using log4net;
using System.Configuration;
using System;
using System.Diagnostics;
using System.Threading;

namespace Exercise1
{
    public class Program
    {

        public static void Main(string[] args)
        {
            
            Logger.InitLogger();
            Logger.Log.Info("Приложение запущено");

            string dateFormat = ConfigurationManager.AppSettings["DateFormat"];
            bool overwrite= Convert.ToBoolean(ConfigurationManager.AppSettings["Overwrite"]);
            //1.1

            var contact = new Contact.Contact("Aleksandr", "Simonov", "Vladimirovich",
                SexEnum.Male, "+7 (904) 672 53 74", new DateTime(1996, 9, 24), "3657878675352", "trainee",
                new Organization("Navicon", "+7 (917) 295 99 46"));

            var contactValidate = new ContactValidater();
            var resultValidate = contactValidate.Validate(contact); //принимать контакт в методе

            Logger.Log.Info(resultValidate);

            //1.3

            using (var cfs = new ContactFileSaver())
            {
                cfs.Save(contact);
            }
            Logger.Log.Info($"Контакт {contact} сохранен");

            //2
            Console.WriteLine("как сохранить?\n" +
                "1. в XMl\n" +
                "2. в CSV");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                Logger.Log.Info($"Пользователь ввел {result}");
                var contactTest = new RandomContact();
                Serializer serializer = new Serializer((OutputFormat) result); //перенести тип в конструктор
                for (int i = 0; i < 3; i++)
                {
                    contact = contactTest.NextFullContact();

                    Logger.Log.Info("Начало выгрузки контакта №" + (i + 1));
                    try
                    {
                        serializer.Serialize(contact, overwrite, dateFormat); //передать контакт
                        Logger.Log.Info("Объект " + contact.GetType() + " сериализован");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Logger.Log.Info("Введен неверный формат сериализации");
                    }
                }
            }


            Console.WriteLine("Для закрытия приложения нажмите любую клавишу\n(кроме выключения!!!!)");
            Console.ReadKey();
            Logger.Log.Info("Приложение завершено");
        }
    }
}

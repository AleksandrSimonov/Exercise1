using Exercise1.Attributes;
using System;
using System.Text.RegularExpressions;

namespace Exercise1
{
    internal class ContactValidater
    {
        private Contact contact;
        private Type type = typeof(Contact);
        public ContactValidater(Contact contact)
        {
            this.contact = contact;
        }

        private string ValidateName()
        {
            var name = nameof(Contact.Name);
            var property = type.GetProperty(name);
            var customAttribute = (MaxLengthAttribute) property.GetCustomAttributes(typeof(MaxLengthAttribute), false)[0];
            var result = customAttribute.MaxLength.CompareTo(contact.Name.Length);

            if (result < 0)
                return "максимальная длина " + property + " " + customAttribute.MaxLength;
            else
                return null;
        }

        private string ValidateSurname()
        {
            var name = nameof(Contact.Surname);
            var property = type.GetProperty(name);
            var customAttribute = (MaxLengthAttribute) property.GetCustomAttributes(typeof(MaxLengthAttribute), false)[0];
            var result = customAttribute.MaxLength.CompareTo(contact.Surname.Length);

            if (result < 0)
                return "максимальная длина " + property + " " + customAttribute.MaxLength;
            else
                return null;
        }

        private string ValidateLastname()
        {
            var name = nameof(Contact.LastName);
            var property = type.GetProperty(name);
            var customAttribute = (MaxLengthAttribute) property.GetCustomAttributes(typeof(MaxLengthAttribute), false)[0];
            var result = customAttribute.MaxLength.CompareTo(contact.LastName.Length);

            if (result < 0)
                return "максимальная длина " + property + " " + customAttribute.MaxLength;
            else
                return null;
        }

        private string ValidateAge()
        {
            var name = nameof(Contact.Birthday);
            var property = type.GetProperty(name);
            var minBirthdayAttribute = (MinBirthdayAttribute) property.GetCustomAttributes(typeof(MinBirthdayAttribute),false)[0];
            var birthday = new DateTime(minBirthdayAttribute.MinYear, minBirthdayAttribute.MinMonth, minBirthdayAttribute.MinDay);
            var result = contact.Birthday.CompareTo(birthday);

            if (result < 0)
                return "Минимальная дата рождения " + property + " " + birthday;
            else
                return null;
        }

        private string ValidatePhoneNumber()
        {
            var name = nameof(Contact.PhoneNumber);
            var property = type.GetProperty(name);
            var regularExpressionAttribute = (RegularExpressionAttribute) property.GetCustomAttributes(typeof(RegularExpressionAttribute),false)[0];
            var regex = new Regex(regularExpressionAttribute.RegularExpression);

            var result = regex.IsMatch(contact.PhoneNumber);

            if (!result)
                return "Неверный формат номера телефона";
            else
                return null;

        }

        public void Validate()
        {
            var validationResult = ValidateName();
            if (validationResult == null)
                Console.WriteLine("Введено корректное имя");
            else
                Console.WriteLine(validationResult);

            validationResult = ValidateSurname();
            if (validationResult == null)
                Console.WriteLine("Введено корректное имя");
            else
                Console.WriteLine(validationResult);

            validationResult = ValidateLastname();
            if (validationResult == null)
                Console.WriteLine("Введено корректное имя");
            else
                Console.WriteLine(validationResult);

            validationResult = ValidateAge();
            if (validationResult == null)
                Console.WriteLine("Введен корректный возраст");
            else
                Console.WriteLine(validationResult);

            validationResult = ValidatePhoneNumber();
            if (validationResult == null)
                Console.WriteLine("Введен корректный номер");
            else
                Console.WriteLine(validationResult);

        }
    }
}

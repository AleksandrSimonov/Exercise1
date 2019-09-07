using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact.ContactValidation
{
    public class ContactValidatorResult
    {
        public bool IsCorrect
        {
            get
            {
                return !Convert.ToBoolean(ErrorsMessage.Count);
            }
        }
        public List<string> ErrorsMessage { get; }
        public override string ToString()
        {
            if (IsCorrect)
                return "Валидация прошла успешно.";
            else
            {
                return "При валидации возникла(и) ошибка(и):\n" +
                    ErrorsMessage.Select(es => es.ToString() + "\n");
            }
        }
    }
}

using System;

namespace Exercise1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class MinBirthdayAttribute : Attribute
    {

        public int MinYear { get; set; }

        public int MinMonth { get; set; }

        public int MinDay { get; set; }

        public MinBirthdayAttribute(int minYear, int minMonth, int minDay)
        {
            MinYear = minYear;
            MinMonth = minMonth;
            MinDay = minDay;
        }
    }
}

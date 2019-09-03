using System;

namespace Exercise1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class RegularExpressionAttribute : Attribute
    {
        public string RegularExpression { get; set; }
        public RegularExpressionAttribute(string regularExpression)
        {
            RegularExpression = regularExpression;
        }
    }
}

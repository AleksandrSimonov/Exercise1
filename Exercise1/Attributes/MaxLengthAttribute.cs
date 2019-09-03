using System;

namespace Exercise1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class MaxLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }

        public MaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }
}

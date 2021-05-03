using System;

namespace ReflectionExampleApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class DateTimeFormatAttribute : Attribute
    {
        public DateTimeFormatAttribute(string dateTimeFormat)
        {
            DateTimeFormat = dateTimeFormat;
        }

        public string DateTimeFormat { get; }
    }
}

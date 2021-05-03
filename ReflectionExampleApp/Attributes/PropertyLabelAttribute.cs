using System;

namespace ReflectionExampleApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class PropertyLabelAttribute : Attribute
    {
        public PropertyLabelAttribute(string label)
        {
            Label = label;
        }

        public string Label { get; }
    }
}

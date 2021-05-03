using ReflectionExampleApp.Attributes;
using System;
using System.Reflection;
using System.Text;

namespace ReflectionExampleApp
{
    class BusinessCard
    {
        [PropertyLabel("Имя")]
        public string FirstName { get; set; }

        [PropertyLabel("Фамилия")]
        public string LastName { get; set; }

        [PropertyLabel("Дата рождения")]
        [DateTimeFormat("dd-MM-yyyy")]
        public DateTime DateOfBirth { get; set; }

        public override string ToString() => $"{nameof(FirstName)}: {FirstName}, \n" +
            $"{nameof(LastName)}: {LastName}, \n" +
            $"{nameof(DateOfBirth)}: {DateOfBirth}.";
    }

    class BusinessCardNoAttributes
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public override string ToString() => $"{nameof(FirstName)}: {FirstName}, \n" +
            $"{nameof(LastName)}: {LastName}, \n" +
            $"{nameof(DateOfBirth)}: {DateOfBirth}.";
    }

    static class Printer
    {
        public static void Print(BusinessCard card)
        {
            var cardType = card.GetType();
            var valueToPrint = new StringBuilder();

            var firstNameValue = ApplyLabelAttributeLogic(
                propertyName: FirstNamePropertyName,
                propertyValue: card.FirstName,
                cardType: cardType);

            valueToPrint.AppendLine(firstNameValue);

            var lastNameValue = ApplyLabelAttributeLogic(
               propertyName: LastNamePropertyName,
               propertyValue: card.LastName,
               cardType: cardType);

            valueToPrint.AppendLine(lastNameValue);

            var dateTimeFormatted = ApplyFormatAttributeLogic(
                propertyName: DateOfBirthPropertyName,
                propertyValue: card.DateOfBirth,
                cardType: cardType);

            var dateTimeValue = ApplyLabelAttributeLogic(
               propertyName: DateOfBirthPropertyName,
               propertyValue: dateTimeFormatted,
               cardType: cardType);

            valueToPrint.AppendLine(dateTimeValue);

            Console.WriteLine(valueToPrint);
        }

        public static void Print(BusinessCardNoAttributes card)
        {
            var cardType = card.GetType();
            var valueToPrint = new StringBuilder();

            var firstNameValue = ApplyLabelAttributeLogic(
                propertyName: FirstNamePropertyName,
                propertyValue: card.FirstName,
                cardType: cardType);

            valueToPrint.AppendLine(firstNameValue);

            var lastNameValue = ApplyLabelAttributeLogic(
               propertyName: LastNamePropertyName,
               propertyValue: card.LastName,
               cardType: cardType);

            valueToPrint.AppendLine(lastNameValue);

            var dateTimeFormatted = ApplyFormatAttributeLogic(
                propertyName: DateOfBirthPropertyName,
                propertyValue: card.DateOfBirth,
                cardType: cardType);

            var dateTimeValue = ApplyLabelAttributeLogic(
               propertyName: DateOfBirthPropertyName,
               propertyValue: dateTimeFormatted,
               cardType: cardType);

            valueToPrint.AppendLine(dateTimeValue);

            Console.WriteLine(valueToPrint);
        }

        static string ApplyLabelAttributeLogic(
            string propertyName, 
            string propertyValue, 
            Type cardType)
        {
            PropertyInfo property = cardType.GetProperty(propertyName);
            var labelAttribute = property.GetCustomAttribute<PropertyLabelAttribute>();

            return labelAttribute != null
                ? $"{labelAttribute.Label}: {propertyValue}"
                : $"{propertyName}: {propertyValue}";
        }

        static string ApplyFormatAttributeLogic(
           string propertyName,
           DateTime propertyValue,
           Type cardType)
        {
            PropertyInfo property = cardType.GetProperty(propertyName);
            var formatAttribute = property.GetCustomAttribute<DateTimeFormatAttribute>();

            return formatAttribute != null
                ? propertyValue.ToString(formatAttribute.DateTimeFormat)
                : propertyValue.ToString();
        }

        static string FirstNamePropertyName = "FirstName";

        static string LastNamePropertyName = "LastName";

        static string DateOfBirthPropertyName = "DateOfBirth";
    }
}

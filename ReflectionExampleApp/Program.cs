using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //этот адрес будет другим на Вашем компьютере
            var libraryPath
                = @"C:\Users\andre\Source\repos\ReflectionExampleApp\ReflectionExample.Library\bin\Debug\ReflectionExample.Library.dll";

            Assembly assembly = Assembly.LoadFrom(libraryPath);
            var printerClass = assembly.GetTypes().First(t => t.FullName == TYPE_NAME);

            /*
            //PrintAllAvailbleTypes(assembly);            
            //PrintAllAvailbleMethods(printerClass);
            //PrintAllAvailbleProperties(printerClass);
            //PrintAllAvailbleFields(printerClass);
            //PrintAllAvailbleConstructors(printerClass);
            */
            /*
            BusinessCard card = new BusinessCard()
            {
                FirstName = "Джон",
                LastName = "Коннор",
                DateOfBirth = new DateTime(1985, 1, 2)
            };

            BusinessCardNoAttributes cardNoAttributes = new BusinessCardNoAttributes()
            {
                FirstName = "Джон",
                LastName = "Коннор",
                DateOfBirth = new DateTime(1985, 1, 2)
            };

            Console.WriteLine(card);
            Console.WriteLine();
            Printer.Print(card);
            Printer.Print(cardNoAttributes);
            */

            /*
            object instance = Activator.CreateInstance(printerClass);

            MethodInfo printMethod = printerClass.GetMethod(PUBLIC_PRINT_NAME);
            printMethod.Invoke(instance, null);

            MethodInfo printWithParameterMethod = printerClass.GetMethod(PUBLIC_PRINT_WITH_PARAMETER_NAME);
            printWithParameterMethod.Invoke(instance, new[] { "ABC" });

            MethodInfo printPrivateMethod = printerClass.GetMethod(PRIVATE_PRINT_NAME, BindingFlags.NonPublic | BindingFlags.Instance);
            printPrivateMethod.Invoke(instance, null);

            PropertyInfo property = printerClass.GetProperty(PROPERTY_NAME);
            Console.WriteLine(property.GetValue(instance));

            FieldInfo privateField = printerClass.GetField(PRIVATE_FIELD_NAME, BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(privateField.GetValue(instance));
            */

            Console.ReadKey();
        }

        static void PrintAllAvailbleTypes(Assembly assembly)
        {
            Console.WriteLine("<--- Type INFO --->");
            foreach (Type type in assembly.GetTypes())
            {                
                Console.WriteLine($"Full name: {type.FullName}");
                Console.WriteLine($"Is visible: {type.IsVisible}");
                Console.WriteLine($"Is serializable: {type.IsSerializable}");
                Console.WriteLine($"Base type: {type.BaseType}");
            }
            Console.WriteLine();
        }

        static void PrintAllAvailbleMethods(Type type)
        {
            Console.WriteLine("<--- Method INFO --->");
            foreach (MethodInfo method in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine();
                Console.WriteLine($"Name: {method.Name}");
                Console.WriteLine($"Return type: {method.ReturnType}");
                Console.WriteLine($"Parameters: ");
                var parameters = method.GetParameters();
                foreach(ParameterInfo parameter in parameters)
                {
                    Console.WriteLine($"Type: {parameter.ParameterType}, " +
                        $"name: {parameter.Name}, " +
                        $"default value: {parameter.DefaultValue}");
                }
            }
            Console.WriteLine();
        }

        static void PrintAllAvailbleProperties(Type type)
        {
            Console.WriteLine("<--- Property INFO --->");
            foreach (PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine($"Name: {property.Name}");
                Console.WriteLine($"Type: {property.PropertyType}");
                Console.WriteLine($"Module: {property.Module}");
                Console.WriteLine($"Declaring type: {property.DeclaringType}");
            }
            Console.WriteLine();
        }

        static void PrintAllAvailbleFields(Type type)
        {
            Console.WriteLine("<--- Field INFO --->");
            foreach (FieldInfo field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"Name: {field.Name}");
                Console.WriteLine($"Type: {field.FieldType}");
                Console.WriteLine($"Is private: {field.IsPrivate}");
                Console.WriteLine($"Is public: {field.IsPublic}");
                Console.WriteLine($"Declaring type: {field.DeclaringType}");
            }
            Console.WriteLine();
        }

        static void PrintAllAvailbleConstructors(Type type)
        {
            Console.WriteLine("<--- Constructor INFO --->");
            foreach (ConstructorInfo constructor in type.GetConstructors())
            {
                Console.WriteLine($"Name: {constructor.Name}");
                Console.WriteLine($"Is static: {constructor.IsStatic}");
                Console.WriteLine($"Is constructor: {constructor.IsConstructor}");
                Console.WriteLine($"Module: {constructor.Module}");
            }
            Console.WriteLine();
        }

        static string TYPE_NAME = "ReflectionExample.Library.Printer";
        static string PUBLIC_PRINT_NAME = "Print";
        static string PUBLIC_PRINT_WITH_PARAMETER_NAME = "PrintWithParameter";
        static string PRIVATE_PRINT_NAME = "PrintPrivate";
        static string PROPERTY_NAME = "StringProperty";
        static string PRIVATE_FIELD_NAME = "_privateFiled";
    }
}

using System;
using System.Reflection;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Получение списка методов класса Console с помощью рефлексии
        Type consoleType = typeof(Console);
        MethodInfo[] consoleMethods = consoleType.GetMethods();

        Console.WriteLine("Методы класса Console:");
        foreach (var method in consoleMethods)
        {
            Console.WriteLine(method.Name);
        }
        Console.WriteLine();

        // 2. Описание класса с несколькими свойствами, создание экземпляра и использование рефлексии
        MyClass myObject = new MyClass
        {
            Property1 = "Value1",
            Property2 = 42,
            Property3 = true
        };

        Type myObjectType = typeof(MyClass);
        PropertyInfo[] properties = myObjectType.GetProperties();

        Console.WriteLine("Свойства и их значения:");
        foreach (var property in properties)
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(myObject)}");
        }
        Console.WriteLine();

        // 3. Вызов метода Substring класса String с помощью рефлексии
        string originalString = "Hello, World!";
        Type stringType = typeof(string);
        MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

        if (substringMethod != null)
        {
            object[] parameters = { 7, 5 }; // Начальный индекс и длина подстроки
            string result = (string)substringMethod.Invoke(originalString, parameters);

            Console.WriteLine($"Результат вызова Substring: {result}");
        }
        Console.WriteLine();

        // 4. Получение списка конструкторов класса List<T> с помощью рефлексии
        Type listType = typeof(List<>);
        Type[] genericArguments = { typeof(int) };
        Type closedListType = listType.MakeGenericType(genericArguments);

        ConstructorInfo[] constructors = closedListType.GetConstructors();

        Console.WriteLine($"Конструкторы класса List<int>:");
        foreach (var constructor in constructors)
        {
            Console.WriteLine(constructor);
        }
    }
}

public class MyClass
{
    public string Property1 { get; set; }
    public int Property2 { get; set; }
    public bool Property3 { get; set; }
}

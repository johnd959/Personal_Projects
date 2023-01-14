using System;

namespace HelloWorld
{
    class Program 
    {
        static void Main(string[] args)
        {
            var John = new Person();
            John.firstName = "John";
            John.lastName = "Yao";
            John.Introduce();
            int result = Calculator.add(1, 2);
            System.Console.WriteLine(result);

        }
    }
}
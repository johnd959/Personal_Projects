using System;

namespace HelloWorld
{
    public class Person
    {
        public string firstName = "";
        public string lastName = "";
        public void Introduce()
        {
            System.Console.WriteLine("My name is " + firstName + " " + lastName);
        }
    }
    public class Calculator
    {
        public static int add(int a, int b)
        {
            return a + b; 
        }
    }
}
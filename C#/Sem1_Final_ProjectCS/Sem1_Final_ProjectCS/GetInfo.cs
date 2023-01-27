using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class GetInfo
    {
        public static Dictionary<string, string> getInfo(Type Type, bool Editing)
        {
            Dictionary<string, string> Buffer = new Dictionary<string, string> { { "ID", "" }, 
                                                                                 { "Name", "" }, 
                                                                                 { "Diagnosis", "" }, 
                                                                                 { "Gender", "" }, 
                                                                                 { "Age", "" } 
                                                                                }; 
            string message = "Please enter";
            if (Editing)
            {
                message += " New";
            }
            if (Type == typeof(Patient))
            {
                message += " Patient";
            }
            else if (Type == typeof(Facility))
            {
                Buffer.Clear();
                Buffer = new Dictionary<string, string>()
                {
                    {"Name", ""}
                };
                message += " Facility"; 
            }
            else if (Type == typeof(Laboratory))
            {
                Buffer.Clear();
                Buffer = new Dictionary<string, string>()
                {
                    {"Name", ""},
                    {"Cost", ""}
                };
                message += " Laboratory";
            }
            else if (Type == typeof(Doctor))
            {
                Buffer.Clear();
                Buffer = new Dictionary<string, string>()
                {
                    {"ID", ""},
                    {"Name", ""},
                    {"Specialty", ""},
                    {"Schedule", ""},
                    {"Qualification", ""},
                    {"Room", ""}
                };
                message += " Doctor"; 
            }
            Dictionary<string, string> newBuffer = Buffer.ToDictionary(entry => entry.Key, entry => entry.Value);
            Console.WriteLine("\r\n");
            foreach (KeyValuePair<string, string> attribute in Buffer)
            {
                string newAttribute = "";
                do
                {
                    Console.Write($"{message} {attribute.Key}: ");
                    if (attribute.Key.Equals("ID"))
                    {
                        if (Editing == false)
                        {
                            newAttribute = Console.ReadLine().TrimEnd();
                            while (Patient.searchPatientByID(newAttribute) != null)
                            {
                                Console.Write("Please enter a nonexisting ID: ");
                                newAttribute = Console.ReadLine().TrimEnd();
                            }
                        }
                        else
                        {
                            newAttribute = Console.ReadLine();
                            while (Patient.searchPatientByID(newAttribute) != null) 
                            {
                                Console.Write("Please enter a nonexsisting ID: ");
                                newAttribute = Console.ReadLine().TrimEnd();  
                            }
                        }
                    }
                    else { newAttribute = Console.ReadLine().TrimEnd(); }
                }
                while (string.IsNullOrEmpty(newAttribute));
                newBuffer[attribute.Key] = newAttribute;
            }
            Console.WriteLine("\r\n");
            return newBuffer;

        }
    }
}

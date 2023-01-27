using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class PatientMenu
    {
        //fields
        private const string MESSAGE = "\r\nPatient Menu\r\n0 - Return to Main Menu\r\n1 - Display patient's list\r\n2 - Search for patient by ID\r\n3 - Add patient\r\n4 - Edit patient info";
        private int option;

        //constructor
        public PatientMenu()
        {
            return; 
        }
        //methods
        public void Initialize()
        {
            do
            {
                Console.WriteLine(MESSAGE);
                this.option = GetInt.getInt("Please select an option: ", "Please select a valid option: ", 0, 4);
                switch (this.option)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            displayPatientList();
                            break;
                        }
                    case 2:
                        {
                            string ID = GetInt.getInt("Enter patient ID: ").ToString();
                            var patientObject = Patient.searchPatientByID(ID);
                            if (patientObject != null)
                            {
                                Console.WriteLine($"\r\n{patientObject.ToString()}");
                            }
                            else
                            {
                                Console.WriteLine("\r\nPatient not found in file");
                            }
                            break;
                        }
                    case 3:
                        {
                            addPatientToList();
                            break;
                        }
                    case 4:
                        {
                            editPatientInfo();
                            break;
                        }
                }

            }
            while (this.option != 0);
        }
        private static void displayPatientList()
        {
            Console.WriteLine("\r\n");
            foreach (Patient patient in Patient.patientList)
            {
                Console.WriteLine(patient.ToString());
            }
            Console.WriteLine("\r\n");
        }

        private static void addPatientToList()
        {
            Dictionary<string, string> attributes= GetInfo.getInfo(typeof(Patient), false);
            Patient patient = new Patient(attributes["ID"], attributes["Name"], attributes["Diagnosis"], attributes["Gender"], attributes["Age"]);
        }

        private static void editPatientInfo()
        {
            string ID = GetInt.getInt("Enter patient ID: ").ToString();
            var searchResult = Patient.searchPatientByID(ID);
            if (searchResult != null)
            {
                Dictionary<string, string> newAttributes = GetInfo.getInfo(typeof(Patient), true);
                searchResult.updateInfo(newAttributes);
            }
            else
            {
                Console.WriteLine("\r\nPatient not found in file");
            }
        }
    }
}

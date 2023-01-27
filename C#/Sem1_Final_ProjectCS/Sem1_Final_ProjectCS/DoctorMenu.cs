using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class DoctorMenu
    {
        private const string MESSAGE = "\r\nDoctor's Menu\r\n0 - Return to Main Menu\r\n1 - Display Doctors list\r\n2 - Search for doctor by ID\r\n3 - Search for doctor by Name\r\n4 - Add doctor\r\n5 - Edit doctor Info";
        private int option;

        public DoctorMenu()
        {
            this.option = 0;
            return;
        }

        public void Initialize()
        {
            do
            {
                Console.WriteLine(MESSAGE);
                option = GetInt.getInt("Please select an option: ", "Please select a valid option: ", 0, 5);
                switch (this.option)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            displayDoctorList(); 
                            break;
                        }
                    case 2:
                        {
                            string ID = GetInt.getInt("Enter doctor ID: ", "").ToString();
                            Doctor searchResult = Doctor.searchDoctorByX("ID", ID);
                            if (searchResult != null)
                            {
                                Console.WriteLine($"\r\n{searchResult}");
                            }
                            else
                            {
                                Console.WriteLine("\r\nDoctor not found in file");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("\r\nEnter Doctor name: ");
                            string name = Console.ReadLine();
                            Doctor searchResult = Doctor.searchDoctorByX("Name", name);
                            if (searchResult != null)
                            {
                                Console.WriteLine(searchResult.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Doctor not found in file");
                            }
                            break;

                        }
                    case 4:
                        {
                            addDoctorToList();
                            break;
                        }
                    case 5:
                        {
                            editDoctorInfo();
                            break;
                        }
                }
            }
            while (this.option != 0);
        }

        private void displayDoctorList()
        {
            Console.WriteLine("\r\n"); 
            foreach (Doctor doctor in Doctor.DoctorList)
            {
                Console.WriteLine(doctor.ToString());
            }
            Console.WriteLine();
        }

        private void addDoctorToList()
        {
            Dictionary<string, string> newAttributes = GetInfo.getInfo(typeof(Doctor), false);
            Doctor doctor = new Doctor(newAttributes["ID"], newAttributes["Name"], newAttributes["Specialty"], newAttributes["Schedule"], newAttributes["Qualification"], newAttributes["Room"]);
        }

        private void editDoctorInfo()
        {
            string ID = GetInt.getInt("Enter Doctor ID: ").ToString();
            var searchResult = Doctor.searchDoctorByX("ID", ID);
            if (searchResult != null)
            {
                Dictionary<string, string> newAttributes = GetInfo.getInfo(typeof(Doctor), true);
                searchResult.updateInfo(newAttributes);
            }
            else
            {
                Console.WriteLine("\r\nDoctor not found in file");
            }


        }

    }
}

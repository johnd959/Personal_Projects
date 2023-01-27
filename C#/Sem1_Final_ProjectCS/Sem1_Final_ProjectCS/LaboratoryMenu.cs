using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class LaboratoryMenu
    {
        private const string MESSAGE = "\r\nLaboratory Menu\r\n0 - Return to Main Menu\r\n1 - Display laboratories list\r\n2 - Add laboratory";
        private int option; 

        public LaboratoryMenu() 
        {
            return; 
        }

        public void Initialize()
        {
            do
            { 
                Console.WriteLine(MESSAGE); 
                this.option = GetInt.getInt("Please select an option: ", "Please select a valid option: ", 0, 2);
                switch (this.option)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1: 
                        {
                            displayLaboratoryList();
                            break;
                        }
                    case 2:
                        {
                            addLaboratoryToList();
                            break;
                        }

                }
            }
            while(this.option != 0);
        }

        public void displayLaboratoryList()
        {
            Console.WriteLine("\r\n");
            foreach (Laboratory laboratory in Laboratory.LaboratroyList)
            {
                Console.WriteLine(laboratory.ToString());
            }
            Console.WriteLine("\r\n");  
        }

        public void addLaboratoryToList()
        {
            Dictionary<string, string> attributes = GetInfo.getInfo(typeof(Laboratory), false);
            Laboratory laboratory = new Laboratory(attributes["Name"], attributes["Cost"]);
        }
    }
}

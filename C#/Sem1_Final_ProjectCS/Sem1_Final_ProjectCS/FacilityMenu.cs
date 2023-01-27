using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class FacilityMenu
    {
        private const string MESSAGE = "\r\nFacilities Menu\r\n0 - Return to Main Menu\r\n1 - Display Facilities List\r\n2 - Add Facility";
        private int option;

        public FacilityMenu()
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
                            displayFacilitesList();
                            break;
                        }
                    case 2:
                        {
                            addFacilityToList();
                            break;
                        }
                }
            } 
            while (this.option != 0);
        }    

        private static void displayFacilitesList()
        {
            Console.WriteLine("\r\n");
            foreach (Facility facility in Facility.facilityList)
            {
                Console.WriteLine(facility.ToString());
            }
            Console.WriteLine("\r\n");  
        }
        private static void addFacilityToList()
        {
            Dictionary<string, string> newAttributes = GetInfo.getInfo(typeof(Facility), false);
            Facility facility = new Facility(newAttributes["Name"]); 
            
        }
    }
}

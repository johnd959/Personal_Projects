using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class MainMenu
    {
        //fields
        private const string MESSAGE = "\r\nMain Menu\r\n0 - Close application\r\n1 - Doctors\r\n2 - Facilities\r\n3 - Laboratories\r\n4 - Patients";
        private int option; 
        //constructor
        public MainMenu() 
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
                            DoctorMenu doctorMenu = new DoctorMenu();
                            doctorMenu.Initialize();
                            break;
                        }
                    case 2:
                        {
                            FacilityMenu facilityMenu = new FacilityMenu();
                            facilityMenu.Initialize();
                            break;
                        }
                    case 3:
                        {
                            LaboratoryMenu laboratoryMenu = new LaboratoryMenu();
                            laboratoryMenu.Initialize();
                            break;
                        }
                    case 4:
                        {
                            PatientMenu patientMenu = new PatientMenu();
                            patientMenu.Initialize(); 
                            break;
                        }
                }
            }
            while (!this.option.Equals(0));
        }
    }
}

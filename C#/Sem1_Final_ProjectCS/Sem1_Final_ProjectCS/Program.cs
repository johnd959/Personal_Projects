using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Patient.Initialize();
            Facility.Initialize();
            Laboratory.Initialize();
            Doctor.Initialize();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Initialize();
            
        }
    }
}

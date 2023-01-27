using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class Facility
    {
        public static List<Facility> facilityList = new List<Facility>();
        private string Name;

        public Facility(string name)
        {
            this.Name = name;
            facilityList.Add(this);
        }

        public static void Initialize()
        {
            facilityList = new List<Facility>();
            foreach (string line in File.ReadLines("../data/facilities.txt"))
            {
                string[] attributes = line.Split(new char[] { '_' });
                Facility facility = new Facility($"{attributes[0]}");
            }
        }

        public override string ToString()
        {
            return this.Name; 
        }

        public string formatFacilityInfo()
        {
            return this.Name;
        }
    }
}

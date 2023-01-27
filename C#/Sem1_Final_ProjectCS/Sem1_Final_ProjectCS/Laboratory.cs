using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class Laboratory
    {
        public static List<Laboratory> LaboratroyList = new List<Laboratory>();
        private string name;
        private string cost;
        
        public Laboratory(string name, string cost)
        {
            this.name = name;
            this.cost = cost;
            Laboratory.LaboratroyList.Add(this);
        }
        public static void Initialize()
        {
            foreach (string line in File.ReadLines("../data/laboratories.txt"))
            {
                string[] attributes = line.Split('_');
                Laboratory laboratory = new Laboratory(attributes[0], attributes[1]);
            }
        }

        public override string ToString()
        {
            return $"{this.name} {this.cost}";
        }

        public string formatLaboratoryIndo()
        {
            return $"{this.name}_{this.cost}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1_Final_ProjectCS
{
    internal class Patient
    {
        private string id;
        private string name;
        private string diagnosis;
        private string gender;
        private string age;
        public static List<Patient> patientList = new List<Patient>();




        //constructor
        public Patient(
            string id,
            string name,
            string diagnosis,
            string gender,
            string age)
        {

            this.id = id;
            this.name = name;
            this.diagnosis = diagnosis;
            this.gender = gender;
            this.age = age;
            Patient.patientList.Add(this);
        }
        //static methods

        public static void Initialize()
        {
            foreach (string line in File.ReadLines("../data/patients.txt"))
            {
                string[] attributes = line.Split('_');
                Patient patient = new Patient(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4]);
            }
        }

        // instance methods
        public override string ToString()
        {
            string result = $"{this.id} {this.name} {this.diagnosis} {this.gender} {this.age}";
            return result;
        }
        public string getInfo(string infoType)
        {
            switch (infoType)
            {
                case "":
                    {
                        return "none selected";
                    }
                case "ID":
                    {
                        return this.id;
                    }
                case "Name":
                    {
                        return this.name;
                    }
                case "Diagnosis":
                    {
                        return this.diagnosis;
                    }
                case "Gender":
                    {
                        return this.gender;
                    }
                case "Age":
                    {
                        return this.age;
                    }
            }
            return "none selected";
        }

        public void updateInfo(Dictionary<string, string> newAttributes)
        {
            foreach (KeyValuePair<string, string> newAttribute in newAttributes)
            {
                switch (newAttribute.Key)
                {
                    case "ID":
                        {
                            this.id = newAttribute.Value;
                            break;
                        }
                    case "Name":
                        {
                            this.name = newAttribute.Value;
                            break;
                        }
                    case "Diagnosis":
                        {
                            this.diagnosis = newAttribute.Value;
                            break;
                        }
                    case "Gender":
                        {
                            this.gender = newAttribute.Value;
                            break;
                        }
                    case "Age":
                        {
                            this.age = newAttribute.Value;
                            break;
                        }
                }
            }
        }

        public static Patient searchPatientByID(string ID)
        {
            foreach (Patient patient in Patient.patientList)
            {
                if (string.Equals(patient.getInfo("ID"), ID))
                {
                    return patient;
                }
            }
            return null;

        }

        public string formatPatientInfo()
        {
            return $"{this.id}_{this.name}_{this.diagnosis}_{this.gender}_{this.age}";
        }
    }
}   

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sem1_Final_ProjectCS
{
    internal class Doctor
    {
        public static List<Doctor> DoctorList = new List<Doctor>();
        private string id;
        private string name;
        private string specialty;
        private string schedule;
        private string qualification;
        private string room;

        public Doctor(string id, string name, string specialty, string schedule, string qualfication, string room)
        {
            this.id = id;
            this.name = name;
            this.specialty = specialty;
            this.schedule = schedule;
            this.qualification = qualfication;
            this.room = room;
            Doctor.DoctorList.Add(this);
        }

        public static void Initialize()
        {
            foreach (string line in File.ReadLines("../data/doctors.txt"))
            {
                string[] attributes = line.Split(new char[] { '_' });
                Doctor doctor = new Doctor(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4], attributes[5]);
            }
        }

        public static Doctor searchDoctorByX(string method, string identifier)
        {
            foreach (Doctor doctor in DoctorList)
            {
                if (doctor.getInfo(method) == identifier)
                {
                    return doctor;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{this.id} {this.name} {this.specialty} {this.schedule} {this.qualification} {this.room}";
        }

        public string formatDoctorInfo()
        {
            return $"{this.id}_{this.name}_{this.specialty}_{this.schedule}_{this.qualification}_{this.room}";
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
                case "Specialty":
                    {
                        return this.specialty;
                    }
                case "Schedule":
                    {
                        return this.schedule;
                    }
                case "Qualification":
                    {
                        return this.qualification;
                    }
                case "Room":
                    {
                        return this.room;
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
                    case "Specialty":
                        {
                            this.specialty = newAttribute.Value;
                            break;
                        }
                    case "Schedule":
                        {
                            this.schedule = newAttribute.Value;
                            break;
                        }
                    case "Qualification":
                        {
                            this.qualification = newAttribute.Value;
                            break;
                        }
                    case "Room":
                        {
                            this.room = newAttribute.Value;
                            break;
                        }
                }
            }
        }
    }

}

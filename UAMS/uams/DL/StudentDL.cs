using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.UI;

namespace uams.DL
{
    public class StudentDL
    {
        public static List<Student> students = new List<Student>();

        public static void addIntoStudentList(Student s)
        {
            students.Add(s);
        }
        public static void viewRegisteredStudents()
        {
            foreach (Student s in StudentDL.students)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " -> " + s.regDegree.degreeName);
                }
            }
        }

        public static void GiveAdmissions()
        {
            students = students.OrderByDescending(x => x.merit).ToList();
            foreach (Student s in students)
            {
                foreach (DegreeProgram d in s.preferences)
                {
                    if (d.seats > 0)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedStudentList = students.OrderByDescending(s => s.merit).ToList();

            return sortedStudentList;
        }
        public static Student StudentExists(string name)
        {
            return students.Find(x => x.name == name);
        }
        public static void viewStudentInDegree(string degName)
        {
            bool found = false;
            Console.WriteLine("Name\t\tFSC\t\tECAT\t\tAge");

            foreach (Student s in students)
            {
                if (s.regDegree != null && s.regDegree.degreeName == degName)
                {
                    Console.WriteLine(s.name + "\t\t" + s.fscMarks + "\t\t" + s.ecatMarks + "\t\t" + s.age);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No students found in " + degName);
            }

        }
        public static Student StudentPresent(string name)
        {
            foreach (Student s in students)
            {
                if (s.name == name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        public static void calculateFeeForAll()
        {
            foreach (Student s in students)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has " + s.calculateFee() + " fees.");
                }
            }
        }
        public static void store(string path)
        {
            StreamWriter f = new StreamWriter(path, false);
            foreach (Student s in students)
            {
                string prefString = "";
                for (int i = 0; i < s.preferences.Count; i++)
                {
                    prefString += s.preferences[i].degreeName + (i < s.preferences.Count - 1 ? ";" : "");
                }
                f.WriteLine(s.name + "," + s.age + "," + s.fscMarks + "," + s.ecatMarks + "," + prefString);
            }
            f.Flush();
            f.Close();
        }

        public static void loadFromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader f = new StreamReader(path);
                string record;
                while ((record = f.ReadLine()) != null)
                {
                    string[] splitted = record.Split(',');
                    string name = splitted[0];
                    int age = int.Parse(splitted[1]);
                    double fsc = double.Parse(splitted[2]);
                    double ecat = double.Parse(splitted[3]);

                    List<DegreeProgram> prefs = new List<DegreeProgram>();
                    string[] degreeNames = splitted[4].Split(';'); 

                    foreach (string dName in degreeNames)
                    {
                        DegreeProgram dp = DegreeProgramDL.isDegreeExists(dName);
                        if (dp != null)
                        {
                            prefs.Add(dp);
                        }
                    }

                    Student s = new Student(name, age, fsc, ecat, prefs);
                    students.Add(s);
                }
                f.Close();
            }
        }
    }
}

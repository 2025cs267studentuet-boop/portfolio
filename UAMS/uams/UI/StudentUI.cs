using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    public class StudentUI
    {
            public static Student takeInputForStudentWithPreferences()
            {
                if (DegreeProgramDL.programList.Count == 0)
                {
                    Console.WriteLine("Add Degree Program first.");
                    return null;
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter FSC Marks: ");
                double fsc = double.Parse(Console.ReadLine());

                Console.Write("Enter ECAT Marks: ");
                double ecat = double.Parse(Console.ReadLine());

                Console.Write("Enter number of preferences: ");
                int p = int.Parse(Console.ReadLine());

                List<DegreeProgram> pref = new List<DegreeProgram>();

                for (int i = 0; i < p; i++)
                {
                    Console.Write("Enter Program Name: ");
                    string pname = Console.ReadLine();

                    DegreeProgram dp = DegreeProgramDL.isDegreeExists(pname);

                    if (dp != null)
                    {
                        if (!pref.Contains(dp))
                        {
                            pref.Add(dp);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Program not found.");
                    }
                }
                Student s = new Student(name, age, fsc, ecat, pref);
                return s;
            }
        public static void printStudents()
        {
            foreach (Student s in StudentDL.students)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got admission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not get admission");
                }
            }
        }
        public static void viewSubjects(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Sub Code\tSub Type");
                foreach (Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }
        public static void registerSubjects(Student s)
        {
            Console.Write("Enter the Subject Code: ");
            string code = Console.ReadLine();

            bool found = false;
            foreach (Subject sub in s.regDegree.subjects)
            {
                if (code == sub.code)
                {
                    found = true;
                    if (s.regStudentSubject(sub))
                    {
                        Console.WriteLine("Subject Registered Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to register: 9 Credit Hour Limit exceeded or Subject already added.");
                    }
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Invalid Subject Code.");
            }
        }
    }
    
}


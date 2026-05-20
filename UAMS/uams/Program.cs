using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;
using uams.UI;

namespace uams
{
    public class Program
    {
        static void Main(string[] args)
        {
            string studentPath = "students.txt";
            string degreePath = "degrees.txt";
            DegreeProgramDL.loadSubjects("subject.txt"); 
            DegreeProgramDL.loadDegrees("degree.txt");   
            StudentDL.loadFromFile("student.txt");
            int option;
            do
            {

                option = Menu();
                clearScreen();
                if (option == 1)
                {
                    if (DegreeProgramDL.programList.Count > 0)
                    {
                        Student s = StudentUI.takeInputForStudentWithPreferences();
                        StudentDL.addIntoStudentList(s);
                        StudentDL.store(studentPath);
                    }

                }
                else if (option == 2)
                {
                    DegreeProgram d = DegreeProgramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                    DegreeProgramDL.store(degreePath);
                }
                else if (option == 3)
                {
                    foreach (Student s in StudentDL.students)
                    {
                        s.calculateMerit();
                    }
                    List<Student> sortedStudentList = StudentDL.sortStudentsByMerit();
                    giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }
                else if (option == 4)
                {
                    StudentDL.viewRegisteredStudents();
                }
                else if (option == 5)
                {
                    string degName;
                    Console.Write("Enter Degree Name: ");
                    degName = Console.ReadLine();
                    StudentDL.viewStudentInDegree(degName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s = StudentDL.StudentPresent(name);
                    if (s != null)
                    {
                        StudentUI.viewSubjects(s);
                        StudentUI.registerSubjects(s);
                    }

                }
                else if (option == 7)
                {
                    StudentDL.calculateFeeForAll();
                }
                clearScreen();
            }
            while (option != 8);

            Console.ReadKey();
        }

        static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.preferences)
                {
                    if (d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }


        static void clearScreen()
        {
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }








        static void header()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("                   UAMS                   ");
            Console.WriteLine("*****************************************");

        }


        static int Menu()
        {
            header();
            int option;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out option))
            {
                return 0;
            }
            return option;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;
namespace uams.UI
{
    public class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            Console.Write("Enter Degree Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Duration: ");
            float dur = float.Parse(Console.ReadLine());

            Console.Write("Enter Seats: ");
            int seats = int.Parse(Console.ReadLine());

            DegreeProgram d = new DegreeProgram(name, dur, seats);

            Console.Write("Enter number of subjects to add: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write("Subject Code: ");
                string code = Console.ReadLine();
                Console.Write("Subject Type: ");
                string type = Console.ReadLine();
                Console.Write("Credit Hours: ");
                int ch = int.Parse(Console.ReadLine());
                Console.Write("Subject Fee: ");
                int fee = int.Parse(Console.ReadLine());

                Subject s = new Subject(code, type, ch, fee);
                if (d.AddSubject(s))
                {
                    Console.WriteLine("Subject Added.");
                }
                else
                {
                    Console.WriteLine("20 Credit Hour Limit Exceeded. Subject not added.");
                }
            }

            return d;
        }
    
}
}

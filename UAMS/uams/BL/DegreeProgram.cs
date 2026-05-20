using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.DL;
using uams.UI;

namespace uams.BL
{
    public class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public int seats;
        public List<Subject> subjects = new List<Subject>();

        public DegreeProgram(string name, float duration, int seats)
        {
            degreeName = name;
            degreeDuration = duration;
            this.seats = seats;
        }

        public int calculateCreditHours()
        {
            int sum = 0;
            foreach (Subject s in subjects)
                sum += s.creditHours;
            return sum;
        }

        public bool isSubjectExists(Subject sub)
        {
            foreach (Subject s in subjects)
                if (s.code == sub.code)
                    return true;
            return false;
        }

        public bool AddSubject(Subject s)
        {
            if (calculateCreditHours() + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true; 
            }
            return false;
        }
    }
}

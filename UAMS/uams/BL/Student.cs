using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.DL;
using uams.UI;

namespace uams.BL
{
    public class Student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;

        public List<DegreeProgram> preferences;
        public DegreeProgram regDegree;
        public List<Subject> regSubjects;

        public Student(string name, int age, double fsc, double ecat, List<DegreeProgram> pref)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fsc;
            this.ecatMarks = ecat;
            this.preferences = pref;
            this.regSubjects = new List<Subject>();
        }

        public void calculateMerit()
        {
            this.merit = (fscMarks * 0.6) + (ecatMarks * 0.4);
        }

        public int getCreditHours()
        {
            int sum = 0;
            foreach (Subject s in regSubjects)
                sum += s.creditHours;
            return sum;
        }
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.creditHours <= 9)
            {
                regSubjects.Add(s);
                return true;
            }
            return false;
        }

        public float calculateFee()
        {
            float total = 0;
            foreach (Subject s in regSubjects)
                total += s.subjectFee;
            return total;
        }
    }
}

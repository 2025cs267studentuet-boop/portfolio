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
    public class DegreeProgramDL
    {
        public static List<DegreeProgram> programList = new List<DegreeProgram>();
        public static List<Subject> globalSubjects = new List<Subject>();
        public static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
        public static void loadSubjects(string path)
        {
            if (File.Exists(path))
            {
                StreamReader f = new StreamReader(path);
                string record;
                while ((record = f.ReadLine()) != null)
                {
                    string[] splitted = record.Split(',');
                    Subject s = new Subject(splitted[0], splitted[1], int.Parse(splitted[2]), int.Parse(splitted[3]));
                    globalSubjects.Add(s);
                }
                f.Close();
            }
        }
        public static void loadDegrees(string path)
        {
            if (File.Exists(path))
            {
                StreamReader f = new StreamReader(path);
                string record;
                while ((record = f.ReadLine()) != null)
                {
                    string[] splitted = record.Split(',');
                    DegreeProgram d = new DegreeProgram(splitted[0], float.Parse(splitted[1]), int.Parse(splitted[2]));
                    string[] types = splitted[3].Split(';');
                    foreach (string t in types)
                    {
                        Subject s = globalSubjects.Find(x => x.type == t);
                        if (s != null)
                        {
                            d.AddSubject(s);
                        }
                    }
                    programList.Add(d);
                }
                f.Close();
            }
        }
        public static DegreeProgram isDegreeExists(string name)
        {
            foreach (DegreeProgram d in programList)
            {
                if (d.degreeName == name)
                {
                    return d;
                }
            }
            return null;
        }
        public static void store(string path)
        {
            StreamWriter f = new StreamWriter(path, false);
            foreach (DegreeProgram d in programList)
            {
                f.WriteLine(d.degreeName + "," + d.degreeDuration + "," + d.seats + "," + d.subjects.Count);
                foreach (Subject s in d.subjects)
                {
                    f.WriteLine(s.code + "," + s.type + "," + s.creditHours + "," + s.subjectFee);
                }
            }
            f.Flush();
            f.Close();
        }

       
    }

}

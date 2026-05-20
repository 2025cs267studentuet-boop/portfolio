using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.DL;
using uams.UI;

namespace uams.BL
{
   public class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFee;

        public Subject(string code, string type, int ch, int fee)
        {
            this.code = code;
            this.type = type;
            this.creditHours = ch;
            this.subjectFee = fee;
        }
    }
}

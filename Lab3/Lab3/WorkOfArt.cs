using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [Serializable]
    public class WorkOfArt
    {
        public String name;
        public int old;
        public String size;

        public override string ToString()
        {
            return name + " " + old + " " + size;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [Serializable]
    public class Funds
    {
        public String name;
        public String addres;        

        public override string ToString()
        {
            return name + " " + addres;
        }
    }
}
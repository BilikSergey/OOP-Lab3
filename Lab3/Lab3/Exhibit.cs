using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [Serializable]
    public class Exhibit
    {
        public WorkOfArt workOfArt;
        public Funds funds;

        public int money;

        public override string ToString()
        {
            return workOfArt + " " + funds + " " + money;
        }
    }
}

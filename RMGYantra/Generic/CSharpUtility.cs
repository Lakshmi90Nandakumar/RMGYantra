using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMGYantra.Generic
{
    public class CSharpUtility
    {
        public int ran()
        {
            Random ran = new Random();
            int r=ran.Next();
            return r;
        }
        public string SysDate()
        {
            DateTime dt= DateTime.Now;
            return dt.ToString();
        }
    }
}

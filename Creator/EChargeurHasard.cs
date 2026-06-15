using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    public class EChargeurHasard : Exception
    {
        public EChargeurHasard(string msg) : base(msg) { }
    }
}

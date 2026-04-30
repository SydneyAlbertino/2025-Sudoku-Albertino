using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class EGrille : Exception 
    { 
        public EGrille(string msg) : base(msg) 
        {
            
        } 
    }
}
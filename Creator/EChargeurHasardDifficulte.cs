using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator
{
    /// <summary>
    /// Si difficulté pas entre 1 et 6
    /// </summary>
    public class EChargeurHasardDifficulte : EChargeurHasard
    {
        public EChargeurHasardDifficulte(string msg) : base(msg) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class EGrilleValeur : EGrille
    {
        /// <summary>
        /// Si la valeur n'est pas dans l’ intervalle des valeurs possibles
        /// </summary>
        /// <param name="msg"></param>
        public EGrilleValeur(string msg) : base(msg)
        {
        }
    }
}

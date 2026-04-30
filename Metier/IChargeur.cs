using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IChargeur
    {
        public Case[,] ChargerGrille();
    }
}

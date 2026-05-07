using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class ChargeurDefaut : IChargeur
    {
        private int taille;

        public ChargeurDefaut(int taille) 
        { 
            this.taille = taille; 
        }

        public Case[,] ChargerGrille()
        {
            int[,] valeurs =
            {
                { -8, -1, -5, -7, -4, +3, -6, -9, +2 },
                { -4, +6, +7, -9, -2, -1, -8, +3, -5 },
                { -3, +9, -2, +8, -5, -6, -7, -1, +4 },
                { +2, -5, +3, +1, -9, +7, -4, -8, -6 },
                { +6, -7, -8, +4, -3, -5, -1, -2, -9 },
                { +1, -4, -9, +6, -8, -2, -3, +5, +7 },
                { -7, -3, +1, +2, -6, -9, +5, -4, +8 },
                { -5, +2, -4, -3, -7, -8, +9, -6, -1 },
                { -9, -8, -6, -5, -1, -4, -2, +7, +3 }
            };
            var cases = new Case[this.taille, this.taille];
            for (int l = 0; l < this.taille; l++)
                for (int c = 0; c < this.taille; c++)
                {
                    int val = valeurs[l, c];
                    bool initiale = val > 0;
                    cases[l, c] = new Case(l, c, Math.Abs(val), initiale, initiale);
                }
            return cases;
        }
    }
}

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
                { 0, 0, 0, 0, 0, 3, 0, 0, 2 },
                { 0, 6, 7, 0, 0, 0, 0, 3, 0 },
                { 0, 9, 0, 8, 0, 0, 0, 0, 4 },
                { 2, 0, 3, 1, 0, 7, 0, 0, 0 },
                { 6, 0, 0, 4, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 6, 0, 0, 0, 5, 7 },
                { 0, 0, 1, 2, 0, 0, 5, 0, 8 },
                { 0, 2, 0, 0, 0, 0, 9, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 7, 3 } 
            };
            Case[,] cases = new Case[this.taille, this.taille];
            for (int l = 0; l < taille; l++)
                for (int c = 0; c < taille; c++)
                    cases[l, c] = new Case(l, c, valeurs[l, c], valeurs[l, c] != 0);
            return cases;
        }
    }
}

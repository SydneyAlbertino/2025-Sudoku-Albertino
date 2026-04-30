using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Case
    {
        private int ligne;
        private int clolone;
        private int valeur;
        private bool affiche

        public int Ligne { get; }
        public int Colonne { get; }
        public int Valeur { get; }
        public bool Affiche { get; }

        public Case(int ligne, int colonne, int valeur, bool affiche)
        {
            this.ligne = ligne;
            this.Colonne = colonne;
            this.Valeur = valeur;
            this.Affiche = affiche;
        }
    }
}

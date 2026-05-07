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
        private int colonne;
        private int valeur;
        private bool affiche;
        private bool initiale;

        public int Ligne { get { return ligne; } }
        public int Colonne { get { return colonne; } }
        public int Valeur { get { return valeur; } }
        public bool Affiche { get { return affiche; } set { affiche = value; } }
        //indique si la case est une case remplie au départ
        public bool Initiale { get { return initiale; } }

        public Case(int ligne, int colonne, int valeur, bool affiche, bool initiale)
        {
            this.ligne = ligne;
            this.colonne = colonne;
            this.valeur = valeur;
            this.affiche = affiche;
            this.initiale = initiale;
        }
    }
}

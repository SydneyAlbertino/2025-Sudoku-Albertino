using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// Représente une case du sudoku, avec sa position, sa valeur, si elle est affichée ou non, si elle est initiale ou non, 
    /// et les choix possibles pour cette case.
    /// </summary>
    public class Case
    {
        private int ligne;
        private int colonne;
        private int valeur;
        private bool affiche;
        private bool initiale;
        private int[] choix;

        public int Ligne { get { return ligne; } }
        public int Colonne { get { return colonne; } }
        public int Valeur { get { return valeur; } }
        public bool Affiche { get { return affiche; } set { affiche = value; } }
        //indique si la case est une case remplie au départ
        public bool Initiale { get { return initiale; } }
        public int[] Choix { get { return choix; } }

        /// <summary>
        /// Constructeur de la classe Case, qui initialise les propriétés de la case.
        /// </summary>
        /// <param name="ligne">La ligne</param>
        /// <param name="colonne"></param>
        /// <param name="valeur"></param>
        /// <param name="affiche"></param>
        /// <param name="initiale"></param>
        public Case(int ligne, int colonne, int valeur, bool affiche, bool initiale)
        {
            this.ligne = ligne;
            this.colonne = colonne;
            this.valeur = valeur;
            this.affiche = affiche;
            this.initiale = initiale;
            this.choix = new int[0];
        }

        /// <summary>
        /// Ajoute ou enlève une valeur dans la liste des choix.
        /// </summary>
        public void Choisir(int valeur)
        {
            if (this.choix.Contains(valeur))
            {
                this.choix = this.choix.Where(v => v != valeur).ToArray();
            }
            else
            {
                this.choix = Choix.Append(valeur).OrderBy(v => v).ToArray();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    /// <summary>
    /// Stocke le couple (ligne, colonne)
    /// </summary>
    public class Coordonnees
    {
        private int taille;
        private int ligne;
        private int colone;

        public int Ligne { get { return ligne; } 
            set 
            {
                if (value < 0 || value >= taille)
                {
                    throw new ECoordonnes($"Ligne {value} invalide.");
                }
                ligne = value;
            } }
        public int Colonne { get { return colone; } 
            set 
            {
                if (value < 0 || value >= taille)
                {
                    throw new ECoordonnes($"Colonne {value} invalide.");
                }
                colone = value;
            } }

        public Coordonnees(int taille) 
        {
            this.taille = taille;
            this.ligne = 0;
            this.colone = 0;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Coordonnees);
        }

        public int GetHashCode()
        {
            return taille.GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Grille
    {
        private int taille;
        private Case[,] cases;
        private readonly IChargeur chargeur;
        private readonly IConsole console;

        public int Taille { get { return taille; } }

        public Grille(int taille, IConsole console, IChargeur chargeur)
        {
            this.taille = taille;
            this.console = console;
            this.chargeur = chargeur;
        }

        public Case GetCase(int ligne, int colonne)
        {
        }

        public void Charger()
        {
        }

        public void Afficher()
        {
        }
    }
}

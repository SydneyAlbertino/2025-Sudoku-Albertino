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
        private bool estCharge;

        public int Taille { get { return taille; } }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="taille">taille de la grille</param>
        /// <param name="console"></param>
        /// <param name="chargeur"></param>
        /// <exception cref="EGrilleTaille">Si la taille différente de 9</exception>
        public Grille(int taille, IConsole console, IChargeur chargeur)
        {
            if (taille != 9)
            {
                throw new EGrilleTaille("La taille doit être 9.");
            }

            this.taille = taille;
            this.console = console;
            this.chargeur = chargeur;
            this.estCharge = false;
        }


        /// <summary>
        /// Renvoie une case
        /// </summary>
        /// <param name="ligne">coordonne de la ligne</param>
        /// <param name="colonne">coordonne de la colone</param>
        /// <returns></returns>
        /// <exception cref="EGrilleCharge">Si la grille n'est pas charger</exception>
        /// <exception cref="EGrilleCoordonnees">Si les coordonne ne sont pas valide </exception>
        public Case GetCase(int ligne, int colonne)
        {
            if (!this.estCharge)
            {
                throw new EGrilleCharge("La grille n'est pas chargée.");
            }

            if (ligne < 0 || ligne >= Taille || colonne < 0 || colonne >= Taille)
            {
                throw new EGrilleCoordonnees("Coordonnées invalides.");
            }
            return cases[ligne, colonne];
        }


        /// <summary>
        /// Charge la grille
        /// </summary>
        public void Charger()
        {
            this.cases=chargeur.ChargerGrille();
            this.estCharge = true;
        }


        /// <summary>
        /// Affiche la grille
        /// </summary>
        /// <exception cref="EGrilleCharge">Si la grille n'est pas charger</exception>
        public void Afficher()
        {
            if (!estCharge)
            {
                throw new EGrilleCharge("La grille n'est pas chargée.");
            }
            console.AfficherGrille(this);
        }
    }
}

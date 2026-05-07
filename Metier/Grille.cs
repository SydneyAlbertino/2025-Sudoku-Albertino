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
        private IChargeur chargeur;
        private IConsole console;
        private bool estCharge;
        private int? valeurSelectionne;
        private Coordonnees curseur;

        //Taille de la grille
        public int Taille { get { return taille; } }
        //Indique la valeur que l’ on veut écrire dans la grille
        public int? ValeurSelectionne { get { return valeurSelectionne; }
            set 
            {
                if (value == null)
                    throw new EGrilleValeurNulle("La valeur ne peut pas être nulle.");
                if (value < 1 || value > Taille)
                    throw new EGrilleValeur($"Valeur {value} hors intervalle.");
                valeurSelectionne = value;
            } }
        //Indique la case ou on veut écrire
        public Coordonnees Curseur { get { return curseur; } set { curseur = value; } }

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
            this.curseur = new Coordonnees(this.taille);
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

        /// <summary>
        /// Ecrit ValeurSelectionne dans la case indiquée par Curseur si c’ est la bonne valeur
        /// </summary>
        /// <exception cref="EGrilleValeurNulle">Si la valeur est null</exception>
        public void MettreValeur()
        {
            if (this.valeurSelectionne == null)
                throw new EGrilleValeurNulle("Aucune valeur sélectionnée.");

            Case c = GetCase(this.curseur.Ligne, this.curseur.Colonne);

            if (!c.Initiale && c.Valeur == this.valeurSelectionne)
            {
                c.Affiche = true;
            }
        }
    }
}

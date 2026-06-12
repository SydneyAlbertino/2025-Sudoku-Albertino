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
        private bool choix;

        //Taille de la grille
        public int Taille { get { return taille; } }
        //Indique la valeur que l’ on veut écrire dans la grille
        public int? ValeurSelectionne 
        { 
            get { return valeurSelectionne; }

            set 
            {
                if (value == null)
                    throw new EGrilleValeurNulle("La valeur ne peut pas être nulle.");
                if (value < 1 || value > Taille)
                    throw new EGrilleValeur($"Valeur {value} hors intervalle.");
                valeurSelectionne = value;
            } 
        }

        //Indique si on est en mode choix ou en mode test
        public bool Choix { get { return choix; } }

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
            if (taille != 4 && taille != 9 && taille != 16)
            {
                throw new EGrilleTaille("La taille doit être 4, 9 ou 16.");
            }

            this.taille = taille;
            this.console = console;
            this.chargeur = chargeur;
            this.estCharge = false;
            this.curseur = new Coordonnees(this.taille);
            this.choix = false;
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
                EnleverChoix();
            }
        }

        /// <summary>
        /// Bascule entre le mode Test et le mode Choix.
        /// </summary>
        public void ChangerMode()
        {
            this.choix = !this.choix;
        }

        // <summary>
        /// Supprime la valeur sélectionnée des choix
        /// </summary>
        public void EnleverChoix()
        {
            if (this.valeurSelectionne == null)
            {
                return;
            }

            int l = Curseur.Ligne;
            int c = Curseur.Colonne;
            int val = this.valeurSelectionne.Value;
            int sous = (int)Math.Sqrt(Taille);

            foreach (int v in this.cases![l, c].Choix.ToArray())
            {
                this.cases[l, c].Choisir(v);
            }

            for (int col = 0; col < Taille; col++)
            {
                if (this.cases[l, col].Choix.Contains(val))
                {
                    this.cases[l, col].Choisir(val);
                }
            }

            for (int lig = 0; lig < Taille; lig++)
            {
                if (this.cases[lig, c].Choix.Contains(val))
                {
                    this.cases[lig, c].Choisir(val);
                }
            }

            int debutLigne = (l / sous) * sous;
            int debutColone = (c / sous) * sous;

            for (int dl = debutLigne; dl < debutLigne + sous; dl++)
            {
                for (int dc = debutColone; dc < debutColone + sous; dc++)
                {
                    if (this.cases[dl, dc].Choix.Contains(val))
                    { 
                        this.cases[dl, dc].Choisir(val);
                    }
                }
            }
        }
    }
}

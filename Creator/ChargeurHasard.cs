using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace Creator
{
    namespace Creator
    {
        /// <summary>
        /// Charge une grille au hasard en fonction de la taille et de la difficulté
        /// </summary>
        public class ChargeurHasard : IChargeur
        {
            private int taille;
            private int sousTaille;
            private int difficulte;
            private Random random = new Random();
            private int[,] grilleVide;


            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="taille">La taille de la grile</param>
            /// <param name="difficulte">la difficulté choisi</param>
            /// <exception cref="EChargeurHasardTaille">Si la taille n'est pas carré</exception>
            /// <exception cref="EChargeurHasardDifficulte">Si difficulté pas entre 1 et 6</exception>
            public ChargeurHasard(int taille, int difficulte)
            {
                if ((this.taille != 4 && taille != 9 && taille != 16))
                    throw new EChargeurHasardTaille("Taille invalide : doit être 4, 9 ou 16.");

                if (difficulte < 1 || difficulte > 6)
                    throw new EChargeurHasardDifficulte("Difficulté doit être entre 1 et 6.");

                int racine = (int)Math.Sqrt(taille);
                this.taille = taille;
                this.sousTaille = racine;
                this.difficulte = difficulte;
                this.grilleVide = new int[taille, taille];
            }

            /// <summary>
            /// Charge la grille
            /// </summary>
            /// <returns></returns>
            public Case[,] ChargerGrille()
            {
                GrilleVide();
                bool[,] initiales = new bool[this.taille, this.taille];

                if (RemplirGrille(this.grilleVide, 0, 0))
                {
                    var casesRestantes = ToutesLesCases();

                    int nbSupprimes = 0;
                    int cible = this.difficulte * 10;
                    bool encorePossible = true;

                    for (int l = 0; l < this.taille; l++)
                    {
                        for (int c = 0; c < this.taille; c++)
                        {
                            initiales[l, c] = true;
                        }
                    }

                    do
                    {
                        var casesRestantesTour = new List<(int l, int c)>(casesRestantes);
                        bool boucleCase = true;

                        do
                        {
                            if (casesRestantesTour.Count == 0)
                            {
                                encorePossible = false;
                                boucleCase = false;
                            }
                            else
                            {
                                int idx = random.Next(casesRestantesTour.Count);
                                var (l, c) = casesRestantesTour[idx];
                                int ancienne = this.grilleVide[l, c];

                                this.grilleVide[l, c] = 0;

                                if (CalculerNombreSolutions(this.grilleVide, 0, 0) == 1)
                                {
                                    initiales[l, c] = false;
                                    nbSupprimes++;
                                    casesRestantes.Remove((l, c));
                                    boucleCase = false;
                                }
                                else
                                {
                                    this.grilleVide[l, c] = ancienne;
                                    casesRestantesTour.RemoveAt(idx);
                                }
                            }
                        }
                        while (boucleCase);
                    }
                    while (nbSupprimes < cible && encorePossible);
                }

                return ConvertirEnCases(this.grilleVide, initiales);
            }

            /// <summary>
            /// Remplit la grille de zéros
            /// </summary>
            private void GrilleVide()
            {
                for (int l = 0; l < this.taille; l++)
                {
                    for (int c = 0; c < this.taille; c++)
                    {
                        this.grilleVide[l, c] = 0;
                    }
                }
            }

            /// <summary>
            /// Remplit la grille
            /// </summary>
            /// <param name="grille">la grille a remplir</param>
            /// <param name="ligne">la ligne</param>
            /// <param name="colonne">la colone</param>
            /// <returns></returns>
            private bool RemplirGrille(int[,] grille, int ligne, int colonne)
            {

                while (ligne < this.taille && grille[ligne, colonne] != 0)
                {
                    var next = CaseSuivante(grille, ligne, colonne);

                    if (next == null)
                    {
                        return true;
                    }
                    (ligne, colonne) = (next.Value.l, next.Value.c);
                }

                if (ligne >= this.taille)
                {
                    return true;
                }

                var valeurs = CalculerValeursPossibles(grille, ligne, colonne);

                valeurs = valeurs.OrderBy(_ => random.Next()).ToList();

                foreach (int val in valeurs)
                {
                    grille[ligne, colonne] = val;

                    var next = CaseSuivante(grille, ligne, colonne);
                    bool reussi = next == null ? true : RemplirGrille(grille, next.Value.l, next.Value.c);

                    if (reussi)
                    {
                        return true;
                    }

                    grille[ligne, colonne] = 0;
                }

                return false;
            }

            private List<int> CalculerValeursPossibles(int[,] grille, int ligne, int colonne)
            {
                var utilisees = new HashSet<int>();

                for (int c = 0; c < this.taille; c++)
                {
                    if (grille[ligne, c] != 0)
                    {
                        utilisees.Add(grille[ligne, c]);
                    }
                }

                for (int l = 0; l < this.taille; l++)
                {
                    if (grille[l, colonne] != 0)
                    {
                        utilisees.Add(grille[l, colonne]);
                    }
                }

                int debutL = (ligne / this.sousTaille) * this.sousTaille;
                int debutC = (colonne / this.sousTaille) * this.sousTaille;

                for (int l = debutL; l < debutL + this.sousTaille; l++)
                {
                    for (int c = debutC; c < debutC + this.sousTaille; c++)
                    {
                        if (grille[l, c] != 0) 
                            utilisees.Add(grille[l, c]);
                    }
                }

                var possibles = new List<int>();
                for (int v = 1; v <= this.taille; v++)
                {
                    if (!utilisees.Contains(v))
                    {
                        possibles.Add(v);
                    }
                }

                return possibles;
            }

            private int CalculerNombreSolutions(int[,] grille, int ligne, int colonne)
            {
                while (ligne < taille && grille[ligne, colonne] != 0)
                {
                    var next = CaseSuivante(grille, ligne, colonne);
                    if (next == null)
                    {
                        return 1;
                    }

                    (ligne, colonne) = (next.Value.l, next.Value.c);
                }

                if (ligne >= this.taille)
                {
                    return 1;
                }


                int total = 0;
                foreach (int val in CalculerValeursPossibles(grille, ligne, colonne))
                {
                    grille[ligne, colonne] = val;
                    var next = CaseSuivante(grille, ligne, colonne);
                    int sols = next == null ? 1 : CalculerNombreSolutions(grille, next.Value.l, next.Value.c);
                    grille[ligne, colonne] = 0;

                    total += sols;

                    if (total > 1) 
                        return total;
                }

                return total;
            }

            /// <summary>
            /// Case suivante (null si dernière case)
            /// </summary>
            /// <param name="grille">la grille</param>
            /// <param name="ligne">la ligne qu'on veut </param>
            /// <param name="colonne">La colone qu'on veut</param>
            /// <returns></returns>
            private (int l, int c)? CaseSuivante(int[,] grille, int ligne, int colonne)
            {
                colonne++;
                if (colonne >= this.taille) 
                { 
                    colonne = 0; ligne++; 
                }

                if (ligne >= this.taille)
                {
                    return null;
                }

                return (ligne, colonne);
            }

            /// <summary>
            /// Toutes les cases de la grille
            /// </summary>
            /// <returns></returns>
            private List<(int l, int c)> ToutesLesCases()
            {
                var liste = new List<(int, int)>();
                for (int l = 0; l < this.taille; l++)
                {
                    for (int c = 0; c < this.taille; c++)
                    {
                        liste.Add((l, c));
                    }
                }
                return liste;
            }

            /// <summary>
            /// Convertit en case
            /// </summary>
            /// <param name="grille"></param>
            /// <param name="initiales"></param>
            /// <returns></returns>
            private Case[,] ConvertirEnCases(int[,] grille, bool[,] initiales)
            {
                var cases = new Case[this.taille, this.taille];
                for (int l = 0; l < this.taille; l++)
                {
                    for (int c = 0; c < this.taille; c++)
                    {
                        bool init = initiales[l, c] && grille[l, c] != 0;
                        cases[l, c] = new Case(l, c, grille[l, c], init, init);
                    }
                }
                return cases;
            }
        }
    }
}
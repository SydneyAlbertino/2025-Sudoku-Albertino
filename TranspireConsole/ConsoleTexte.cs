using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace TranspireConsole
{
    public class ConsoleTexte : IConsole
    {
        public void AfficherGrille(Grille grille)
        {
            Console.Clear();

            int curseurL = grille.Curseur.Ligne;
            int curseurC = grille.Curseur.Colonne;


            EcrireLigneHorizontale(grille.Taille, 0, curseurL, curseurC, "top");

            for (int l = 0; l < grille.Taille; l++)
            {

                EcrireSepaVertical(l, -1, curseurL, curseurC);

                for (int c = 0; c < grille.Taille; c++)
                {
                    var cas = grille.GetCase(l, c);
                    bool estCurseur = l == curseurL && c == curseurC;


                    if (cas.Affiche)
                    {
                        if (estCurseur)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        else
                        {
                            if (cas.Initiale)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        string val = cas.Affiche ? cas.Valeur.ToString() : " ";
                        Console.Write($" {val} ");
                        Console.ResetColor();
                    }

                    else
                    {
                        if (cas.Choix.Length > 0)
                        {
                            string choixstr = string.Join(" ", cas.Choix).PadRight(3).Substring(0);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(choixstr);
                            Console.ResetColor();
                        }

                        else
                        {
                            Console.Write("   ");
                        }
                    }
                    EcrireSepaVertical(l, c, curseurL, curseurC);
                }

                Console.WriteLine();


                if (l < grille.Taille - 1)
                {
                    EcrireLigneHorizontale(grille.Taille, l + 1, curseurL, curseurC, "mid");
                }
            }

            EcrireLigneHorizontale(grille.Taille, grille.Taille, curseurL, curseurC, "bot");


            Console.Write("\nValeur sélectionnée : ");
            for (int i = 1; i <= grille.Taille; i++)
            {
                if (grille.ValeurSelectionne == i)
                {
                    Console.ForegroundColor = grille.Choix ? ConsoleColor.Green : ConsoleColor.Red;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(i + " ");
                Console.ResetColor();
            }
            Console.Write("\nMode: ");
            Console.ForegroundColor = grille.Choix ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(grille.Choix ? "Choix" : "Test");
            Console.ResetColor();
        }

        /// <summary>
        /// Écrit un séparateur en rouge si la case à gauche ou à droite est le curseur.
        /// colonneGauche = -1 signifie le bord gauche de la grille.
        /// </summary>
        private void EcrireSepaVertical(int ligne, int colonneGauche, int curseurL, int curseurC)
        {
            bool estRouge = ligne == curseurL &&
                            (colonneGauche == curseurC || colonneGauche + 1 == curseurC);

            if (estRouge)
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("\u2502");
            Console.ResetColor();
        }

        /// <summary>
        /// Écrit une ligne horizontale (haut/milieu/bas) en coloriant en rouge
        /// le segment au-dessus ou en-dessous de la case curseur.
        /// </summary>
        private void EcrireLigneHorizontale(int taille, int ligneIndex, int curseurL, int curseurC, string type)
        {
            char gauche = type == "top" ? '\u250C' : type == "mid" ? '\u251C' : '\u2514';
            char milieu = type == "top" ? '\u252C' : type == "mid" ? '\u253C' : '\u2534';
            char droite = type == "top" ? '\u2510' : type == "mid" ? '\u2524' : '\u2518';

            bool ligneEstPresCurseur = ligneIndex == curseurL || ligneIndex == curseurL + 1;

            Console.Write(gauche);

            for (int c = 0; c < taille; c++)
            {
                bool segmentRouge = ligneEstPresCurseur && c == curseurC;

                if (segmentRouge)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("\u2500\u2500\u2500");
                Console.ResetColor();

                if (c < taille - 1)
                    Console.Write(milieu);
            }

            Console.WriteLine(droite);
        }
    }
}
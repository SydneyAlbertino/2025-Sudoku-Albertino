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
            Console.WriteLine("\u250C" + string.Join("\u252C", Enumerable.Repeat("\u2500\u2500\u2500", grille.Taille)) + "\u2510");
            for (int l = 0; l < grille.Taille; l++)
            {
                Console.Write("\u2502");
                for (int c = 0; c < grille.Taille; c++)
                {
                    var cas = grille.GetCase(l, c);
                    string val = cas.Affiche ? cas.Valeur.ToString() : " ";
                    Console.Write($" {val} \u2502");
                }
                Console.WriteLine();
                if (l < grille.Taille - 1)
                    Console.WriteLine("\u251C" + string.Join("\u253C", Enumerable.Repeat("\u2500\u2500\u2500", grille.Taille)) + "\u2524");
            }
            Console.WriteLine("\u2514" + string.Join("\u2534", Enumerable.Repeat("\u2500\u2500\u2500", grille.Taille)) + "\u2518");
        }
    }
}

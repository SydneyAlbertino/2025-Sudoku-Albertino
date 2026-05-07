using Metier;
using TranspireConsole;

var chargeur = new ChargeurDefaut(9);
var console = new ConsoleTexte();
var grille = new Grille(9, console, chargeur);
grille.Charger();

bool continuer = true;
while (continuer)
{
    grille.Afficher();

    ConsoleKeyInfo touche = Console.ReadKey(true);

    switch (touche.Key)
    {

        case ConsoleKey.UpArrow:
            if (grille.Curseur.Ligne > 0)
                grille.Curseur.Ligne--;
            break;

        case ConsoleKey.DownArrow:
            if (grille.Curseur.Ligne < grille.Taille - 1)
                grille.Curseur.Ligne++;
            break;

        case ConsoleKey.LeftArrow:
            if (grille.Curseur.Colonne > 0)
                grille.Curseur.Colonne--;
            break;

        case ConsoleKey.RightArrow:
            if (grille.Curseur.Colonne < grille.Taille - 1)
                grille.Curseur.Colonne++;
            break;


        case ConsoleKey.Enter:
            try { grille.MettreValeur(); }
            catch (EGrilleValeurNulle) {  }
            break;

        case ConsoleKey.Q:
            continuer = false;
            break;


        default:
            int val = Convert.ToInt32(touche.KeyChar - '0');
            if (val >= 1 && val <= 9)
                try { grille.ValeurSelectionne = val; }
                catch (EGrilleValeur) {  }
            break;
    }
}
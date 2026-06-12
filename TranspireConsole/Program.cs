using Creator;
using Creator.Creator;
using Metier;
using TranspireConsole;

Console.Write("Difficulté (1 à 6) : ");
int difficulte = int.Parse(Console.ReadLine()!);

ChargeurHasard chargeur;
try
{
    chargeur = new ChargeurHasard(9, difficulte);
}
catch (EChargeurHasardDifficulte ex)
{
    Console.WriteLine($"Erreur : {ex.Message}");
    return;
}

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
            if (grille.Curseur.Ligne > 0) grille.Curseur.Ligne--;
            break;

        case ConsoleKey.DownArrow:
            if (grille.Curseur.Ligne < 8) grille.Curseur.Ligne++;
            break;

        case ConsoleKey.LeftArrow:
            if (grille.Curseur.Colonne > 0) grille.Curseur.Colonne--;
            break;

        case ConsoleKey.RightArrow:
            if (grille.Curseur.Colonne < 8) grille.Curseur.Colonne++;
            break;

        case ConsoleKey.Enter:
            if (grille.Choix)
            {
                if (grille.ValeurSelectionne != null)
                {
                    var cas = grille.GetCase(grille.Curseur.Ligne, grille.Curseur.Colonne);
                    if (!cas.Initiale && !cas.Affiche)
                        cas.Choisir(grille.ValeurSelectionne.Value);
                }
            }
            else
            {
                try { grille.MettreValeur(); }
                catch (EGrilleValeurNulle) { }
            }
            break;

        case ConsoleKey.Q:
            continuer = false;
            break;

        case ConsoleKey.M:
            grille.ChangerMode();
            break;

        default:
            int val = Convert.ToInt32(touche.KeyChar - '0');
            if (val >= 1 && val <= 9)
            {
                try 
                { 
                    grille.ValeurSelectionne = val; 
                }
                catch (EGrilleValeur) 
                { 
                }
            }
            break;
    }
}
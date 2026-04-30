// See https://aka.ms/new-console-template for more information
using Metier;
using TranspireConsole;

var chargeur = new ChargeurDefaut(9);
var console = new ConsoleTexte();
var grille = new Grille(9, console, chargeur);
grille.Charger();
grille.Afficher();

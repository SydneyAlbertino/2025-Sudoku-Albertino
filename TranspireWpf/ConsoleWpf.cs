using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;


namespace TranspireWpf
{
    public class ConsoleWpf : IConsole
    {
        private Grid grid;
        private Action<int, int> caseClique;

        public ConsoleWpf(Grid grid, Action<int, int> onCaseCliquee)
        {
            this.grid = grid;
            this.caseClique = onCaseCliquee;
        }

        public void AfficherGrille(Grille grille)
        {
            this.grid.Children.Clear();
            this.grid.RowDefinitions.Clear();
            this.grid.ColumnDefinitions.Clear();


            for (int i = 0; i < grille.Taille; i++)
            {
                this.grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                this.grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int l = 0; l < grille.Taille; l++)
            {
                for (int c = 0; c < grille.Taille; c++)
                {
                    Case cas = grille.GetCase(l, c);
                    bool estCurseur = grille.Curseur.Ligne == l && grille.Curseur.Colonne == c;

                    var border = new Border
                    {
                        BorderBrush = estCurseur ? Brushes.Red : Brushes.Black,
                        BorderThickness = EpaisseurBordure(l, c, estCurseur),
                        Background = Brushes.White,
                        Cursor = Cursors.Hand
                    };

                    if (cas.Affiche)
                    {
                        border.Child = new TextBlock
                        {
                            Text = cas.Valeur.ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 20,
                            FontWeight = FontWeights.Bold,
                            Foreground = cas.Initiale ? Brushes.RoyalBlue : Brushes.Black
                        };
                    }

                    int ligne = l;
                    int colonne = c;
                    border.MouseLeftButtonDown += (s, e) => this.caseClique(ligne, colonne);

                    Grid.SetRow(border, l);
                    Grid.SetColumn(border, c);
                    this.grid.Children.Add(border);
                }
            }
        }

        /// <summary>
        /// Épaissit les bordures pour délimiter les sous-grilles 3x3.
        /// Si la case est le curseur, toutes les bordures sont épaisses et rouges.
        /// </summary>
        private Thickness EpaisseurBordure(int ligne, int colonne, bool estCurseur)
        {
            if (estCurseur)
                return new Thickness(3);

            double gauche = (colonne % 3 == 0) ? 3 : 0.5;
            double haut = (ligne % 3 == 0) ? 3 : 0.5;
            double droite = (colonne == 8) ? 3 : 0.5;
            double bas = (ligne == 8) ? 3 : 0.5;
            return new Thickness(gauche, haut, droite, bas);
        }
    }
}

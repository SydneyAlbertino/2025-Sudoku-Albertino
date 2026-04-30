using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace TranspireWpf
{
    public class ConsoleWpf : IConsole
    {
        private readonly Grid _grid;

        public ConsoleWpf(Grid grid)
        {
            _grid = grid;
        }

        public void AfficherGrille(Grille grille)
        {
            _grid.Children.Clear();
            _grid.RowDefinitions.Clear();
            _grid.ColumnDefinitions.Clear();

            for (int i = 0; i < grille.Taille; i++)
            {
                _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int l = 0; l < grille.Taille; l++)
            {
                for (int c = 0; c < grille.Taille; c++)
                {
                    Case cas = grille.GetCase(l, c);

                    var border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = EpaisseurBordure(l, c),
                        Background = Brushes.White
                    };

                    if (cas.Affiche)
                    {
                        border.Child = new TextBlock
                        {
                            Text = cas.Valeur.ToString(),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 20,
                            FontWeight = FontWeights.Bold
                        };
                    }

                    Grid.SetRow(border, l);
                    Grid.SetColumn(border, c);
                    _grid.Children.Add(border);
                }
            }
        }

        private Thickness EpaisseurBordure(int ligne, int colonne)
        {
            double gauche = (colonne % 3 == 0) ? 3 : 0.5;
            double haut = (ligne % 3 == 0) ? 3 : 0.5;
            double droite = (colonne == 8) ? 3 : 0.5;
            double bas = (ligne == 8) ? 3 : 0.5;
            return new Thickness(gauche, haut, droite, bas);
        }
    }
}

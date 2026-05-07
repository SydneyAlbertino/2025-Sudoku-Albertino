using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Metier;


namespace TranspireWpf
{
    public partial class MainWindow : Window
    {
        private Grille grille;
        private ConsoleWpf console;

        public MainWindow()
        {
            InitializeComponent();

            this.console = new ConsoleWpf(GrilleWpf, OnCaseCliquee);
            var chargeur = new ChargeurDefaut(9);
            this.grille = new Grille(9, this.console, chargeur);

            this.grille.Charger();
            CreerBoutonsValeurs();
            this.grille.Afficher();
        }

        private void CreerBoutonsValeurs()
        {
            for (int i = 1; i <= 9; i++)
            {
                int valeur = i;
                var btn = new Button
                {
                    Content = i.ToString(),
                    Width = 40,
                    Height = 40,
                    Margin = new Thickness(3),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Tag = valeur
                };
                btn.Click += (s, e) => SelectionnerValeur(valeur);
                PanneauValeurs.Children.Add(btn);
            }
        }

        private void SelectionnerValeur(int valeur)
        {
            this.grille.ValeurSelectionne = valeur;
            MettreAJourBoutons();
            this.grille.Afficher();
        }

        /// <summary>
        /// Met en évidence le bouton de la valeur sélectionnée en bleu.
        /// </summary>
        private void MettreAJourBoutons()
        {
            foreach (Button btn in PanneauValeurs.Children)
            {
                if ((int)btn.Tag == this.grille.ValeurSelectionne)
                {
                    btn.Background = Brushes.CornflowerBlue;
                    btn.Foreground = Brushes.White;
                }
                else
                {
                    btn.Background = SystemColors.ControlBrush;
                    btn.Foreground = Brushes.Black;
                }
            }
        }

        private void OnCaseCliquee(int ligne, int colonne)
        {
            this.grille.Curseur.Ligne = ligne;
            this.grille.Curseur.Colonne = colonne;

            if (this.grille.ValeurSelectionne != null)
            {
                try { this.grille.MettreValeur(); }
                catch (EGrilleValeurNulle) { }
            }

            this.grille.Afficher();
        }
    }
}
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
using Creator.Creator;
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

            var dialog = new DifficulteDialog();
            if (dialog.ShowDialog() != true) 
            { 
                Close(); return; 
            }

            int difficulte = dialog.Difficulte;

            this.console = new ConsoleWpf(GrilleWpf, OnCaseCliquee);
            var chargeur = new ChargeurHasard(9, difficulte);
            this.grille = new Grille(9, this.console, chargeur);

            this.grille.Charger();
            CreerBoutonsValeurs();
            MettreAJourMode();
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
            Brush couleurActive = this.grille.Choix ? Brushes.SeaGreen : Brushes.CornflowerBlue;

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
                if (this.grille.Choix)
                {
                    Case cas = this.grille.GetCase(ligne, colonne);
                    if (!cas.Initiale && !cas.Affiche)
                    {
                        cas.Choisir(this.grille.ValeurSelectionne.Value);
                    }
                }
                else
                {
                    try { this.grille.MettreValeur(); }
                    catch (EGrilleValeurNulle) { }
                }
            }

            this.grille.Afficher();
        }

        /// <summary>
        /// Met à jour le label du mode (Test = rouge, Choix = vert).
        /// </summary>
        private void MettreAJourMode()
        {
            if (this.grille.Choix)
            {
                LabelMode.Text = "Choix";
                LabelMode.Foreground = Brushes.SeaGreen;
            }
            else
            {
                LabelMode.Text = "Test";
                LabelMode.Foreground = Brushes.Red;
            }
        }

        private void LabelMode_Click(object sender, MouseButtonEventArgs e)
        {
            this.grille.ChangerMode();
            MettreAJourMode();
            MettreAJourBoutons();
            this.grille.Afficher();
        }


    }
}
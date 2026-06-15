using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TranspireWpf
{
    public partial class DifficulteDialog : Window
    {
        public int Difficulte { get; private set; }

        public DifficulteDialog()
        {
            InitializeComponent();

            SliderDifficulte.ValueChanged += (s, e) => MettreAJourLabel();
            MettreAJourLabel();
        }

        private void MettreAJourLabel()
        {
            int diff = (int)SliderDifficulte.Value;
            LabelDifficulte.Text = $"Difficulté {diff} — {diff * 10} cases vides";
        }

        private void BtnCommencer_Click(object sender, RoutedEventArgs e)
        {
            Difficulte = (int)SliderDifficulte.Value;
            DialogResult = true;
        }
    }
}

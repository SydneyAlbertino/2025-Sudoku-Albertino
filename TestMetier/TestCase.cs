using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace TestMetier
{
    public class testCase
    {
        /// <summary>
        /// Test du controleur avec des valeurs normals
        /// </summary>
        [Fact]
        public void ConstructeurClassique()
        {
            var c = new Case(2, 5, 7, true,true);

            Assert.Equal(2, c.Ligne);
            Assert.Equal(5, c.Colonne);
            Assert.Equal(7, c.Valeur);
            Assert.True(c.Affiche);
            Assert.True(c.Initiale);
        }



        [Fact]
        public void Case_ProprietesCorrectes_QuandNonAffiche()
        {
            var c = new Case(0, 0, 0, false, true);

            Assert.Equal(0, c.Valeur);
            Assert.False(c.Affiche);
        }

        [Fact]
        public void Case_LigneZero_EstValide()
        {
            var c = new Case(0, 0, 1, true, true);
            Assert.Equal(0, c.Ligne);
        }


        [Fact]
        public void Case_ColonneHuit_EstValide()
        {
            var c = new Case(0, 8, 9, true, true);
            Assert.Equal(8, c.Colonne);
        }

        [Fact]
        /// <summary>
        /// Setter Affiche modifiable
        /// </summary>
        public void Case_SetAffiche()
        {
            Case c = new Case(0, 0, 5, false, false);
            c.Affiche = true;
            Assert.True(c.Affiche);
        }

        [Fact]
        public void Choix_VideAuDepart()
        {
            Case c = new Case(0, 0, 0, false, false);
            Assert.Empty(c.Choix);
        }

        [Fact]
        public void Choisir_AjouteValeur()
        {
            Case c = new Case(0, 0, 0, false, false);
            c.Choisir(5);
            Assert.Contains(5, c.Choix);
        }

        [Fact]
        public void Choisir_EnleveValeurDejaPresente()
        {
            Case c = new Case(0, 0, 0, false, false);
            c.Choisir(5);
            c.Choisir(5);
            Assert.DoesNotContain(5, c.Choix);
        }

        [Fact]
        public void Choisir_PlusieursValeurs()
        {
            Case c = new Case(0, 0, 0, false, false);
            c.Choisir(3);
            c.Choisir(7);
            c.Choisir(1);
            Assert.Contains(3, c.Choix);
            Assert.Contains(7, c.Choix);
            Assert.Contains(1, c.Choix);
        }

        [Fact]
        public void Choisir_ValeursTries()
        {
            Case c = new Case(0, 0, 0, false, false);
            c.Choisir(7);
            c.Choisir(2);
            c.Choisir(5);
            Assert.Equal(new int[] { 2, 5, 7 }, c.Choix);
        }

        [Fact]
        public void Choisir_EnleveSeulementValeurCible()
        {
            Case c = new Case(0, 0, 0, false, false);
            c.Choisir(2);
            c.Choisir(5);
            c.Choisir(7);
            c.Choisir(5);
            Assert.Equal(new int[] { 2, 7 }, c.Choix);
        }
    }
}

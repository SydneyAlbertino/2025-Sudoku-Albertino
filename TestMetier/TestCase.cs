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
            var c = new Case(2, 5, 7, true);

            Assert.Equal(2, c.Ligne);
            Assert.Equal(5, c.Colonne);
            Assert.Equal(7, c.Valeur);
            Assert.True(c.Affiche);
        }



        [Fact]
        public void Case_ProprietesCorrectes_QuandNonAffiche()
        {
            var c = new Case(0, 0, 0, false);

            Assert.Equal(0, c.Valeur);
            Assert.False(c.Affiche);
        }

        [Fact]
        public void Case_LigneZero_EstValide()
        {
            var c = new Case(0, 0, 1, true);
            Assert.Equal(0, c.Ligne);
        }


        [Fact]
        public void Case_ColonneHuit_EstValide()
        {
            var c = new Case(0, 8, 9, true);
            Assert.Equal(8, c.Colonne);
        }
    }
}

using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMetier
{
    public class TestCoordonnes
    {
        [Fact]
        /// <summary>
        /// Constructeur : coordonnées initialisées à (0,0)
        /// </summary>
        public void Coordonnes_Constructeur_00()
        {
            Coordonnees c = new Coordonnees(9);
            Assert.Equal(0, c.Ligne);
            Assert.Equal(0, c.Colonne);
        }

        [Fact]
        /// <summary>
        /// Setter Ligne valide
        /// </summary>
        public void Coordonnes_SetLigne_Valide()
        {
            Coordonnees c = new Coordonnees(9);
            c.Ligne = 5;
            Assert.Equal(5, c.Ligne);
        }

        [Fact]
        /// <summary>
        /// Setter Colonne valide
        /// </summary>
        public void Coordonnes_SetColonne_Valide()
        {
            Coordonnees c = new Coordonnees(9);
            c.Colonne = 8;
            Assert.Equal(8, c.Colonne);
        }

        [Fact]
        /// <summary>
        /// Setter Ligne négative lève ECoordonnes
        /// </summary>
        public void Coordonnes_SetLigneNegative()
        {
            Coordonnees c = new Coordonnees(9);
            Assert.Throws<ECoordonnes>(() => c.Ligne = -1);
        }

        [Fact]
        /// <summary>
        /// Setter Ligne égale à taille lève ECoordonnes
        /// </summary>
        public void Coordonnes_SetLigneTaille()
        {
            Coordonnees c = new Coordonnees(9);
            Assert.Throws<ECoordonnes>(() => c.Ligne = 9);
        }

        [Fact]
        /// <summary>
        /// Setter Colonne négative lève ECoordonnes
        /// </summary>
        public void Coordonnes_SetColonneNegative()
        {
            Coordonnees c = new Coordonnees(9);
            Assert.Throws<ECoordonnes>(() => c.Colonne = -1);
        }

        [Fact]
        /// <summary>
        /// Setter Colonne égale à taille lève ECoordonnes
        /// </summary>
        public void Coordonnes_SetColonneTaille()
        {
            Coordonnees c = new Coordonnees(9);
            Assert.Throws<ECoordonnes>(() => c.Colonne = 9);
        }

        [Fact]
        /// <summary>
        /// Equals : deux coordonnées identiques sont égales
        /// </summary>
        public void Coordonnes_Equals_Meme()
        {
            Coordonnees c1 = new Coordonnees(9);
            Coordonnees c2 = new Coordonnees(9);
            c1.Ligne = 3; c1.Colonne = 4;
            c2.Ligne = 3; c2.Colonne = 4;
            bool rep = c1.Equals(c2);
            Assert.True(rep);
        }

        [Fact]
        /// <summary>
        /// Equals : deux coordonnées différentes ne sont pas égales
        /// </summary>
        public void Coordonnes_Equals_diff()
        {
            Coordonnees c1 = new Coordonnees(9);
            Coordonnees c2 = new Coordonnees(9);
            c1.Ligne = 1; c1.Colonne = 2;
            c2.Ligne = 3; c2.Colonne = 4;
            bool rep = c1.Equals(c2);
            Assert.True(rep);
        }

        [Fact]
        /// <summary>
        /// GetHashCode : deux coordonnées égales ont le même hash
        /// </summary>
        public void Coordonnes_GetHashCode_Meme()
        {
            Coordonnees c1 = new Coordonnees(9);
            Coordonnees c2 = new Coordonnees(9);
            c1.Ligne = 2; c1.Colonne = 7;
            c2.Ligne = 2; c2.Colonne = 7;
            Assert.Equal(c1.GetHashCode(), c2.GetHashCode());
        }
    }
}

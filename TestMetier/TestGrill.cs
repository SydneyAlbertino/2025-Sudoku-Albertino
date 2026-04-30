using Metier;
using Xunit;

namespace TestMetier
{
    public class TestGrille
    {

        [Fact]
        /// <summary>
        /// Constructeur avec taille valide
        /// </summary>
        public void Grille_TailleNeuf()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Equal(9, g.Taille);
        }

        [Fact]
        /// <summary>
        /// Constructeur avec taille invalide (trop petite)
        /// </summary>
        public void Grille_TailleHuit_LeveException()
        {
            Assert.Throws<EGrilleTaille>(() => new Grille(8, null, new ChargeurDefaut(8)));
        }

        [Fact]
        /// <summary>
        /// Constructeur avec taille invalide (trop grande)
        /// </summary>
        public void Grille_TailleDix_LeveException()
        {
            Assert.Throws<EGrilleTaille>(() => new Grille(10, null, new ChargeurDefaut(10)));
        }

        [Fact]
        /// <summary>
        /// Constructeur avec taille zéro
        /// </summary>
        public void Grille_TailleZero_LeveException()
        {
            Assert.Throws<EGrilleTaille>(() => new Grille(0, null, new ChargeurDefaut(0)));
        }

        // ════════════════════════════════════════════════════
        //  GetCase — grille non chargée
        // ════════════════════════════════════════════════════

        [Fact]
        /// <summary>
        /// GetCase sans avoir chargé la grille lève EGrilleCharge
        /// </summary>
        public void Grille_GetCase_SansCharger_LeveException()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Throws<EGrilleCharge>(() => g.GetCase(0, 0));
        }

        // ═══════════════════════════════════════════════════=
        //  GetCase — coordonnées invalides
        // ════════════════════════════════════════════════════

        [Fact]
        /// <summary>
        /// GetCase avec une ligne négative lève EGrilleCoordonnees
        /// </summary>
        public void Grille_GetCase_LigneNegative_LeveException()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();
            Assert.Throws<EGrilleCoordonnees>(() => g.GetCase(-1, 0));
        }

        [Fact]
        /// <summary>
        /// GetCase avec une colonne négative lève EGrilleCoordonnees
        /// </summary>
        public void Grille_GetCase_ColonneNegative_LeveException()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();
            Assert.Throws<EGrilleCoordonnees>(() => g.GetCase(0, -1));
        }

        [Fact]
        /// <summary>
        /// GetCase avec une ligne égale à la taille lève EGrilleCoordonnees
        /// </summary>
        public void Grille_GetCase_LigneEgaleATaille_LeveException()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();
            Assert.Throws<EGrilleCoordonnees>(() => g.GetCase(9, 0));
        }

        [Fact]
        /// <summary>
        /// GetCase avec une colonne égale à la taille lève EGrilleCoordonnees
        /// </summary>
        public void Grille_GetCase_ColonneEgaleATaille_LeveException()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();
            Assert.Throws<EGrilleCoordonnees>(() => g.GetCase(0, 9));
        }

        // ════════════════════════════════════════════════════
        //  GetCase — coordonnées valides
        // ════════════════════════════════════════════════════

        [Fact]
        /// <summary>
        /// GetCase retourne bien une case non null après chargement
        /// </summary>
        public void Grille_GetCase_ApresChargement_RetourneCase()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();
            Case c = g.GetCase(0, 0);
            Assert.NotNull(c);
        }

        [Fact]
        /// <summary>
        /// GetCase retourne une case avec les bonnes coordonnées
        /// </summary>
        public void Grille_GetCase_CoordonneesCorrectes()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();
            Case c = g.GetCase(3, 5);
            Assert.Equal(3, c.Ligne);
            Assert.Equal(5, c.Colonne);
        }

        // ════════════════════════════════════════════════════
        //  Afficher
        // ════════════════════════════════════════════════════

        [Fact]
        /// <summary>
        /// Afficher sans avoir chargé lève EGrilleCharge
        /// </summary>
        public void Grille_Afficher_SansCharger_LeveException()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Throws<EGrilleCharge>(() => g.Afficher());
        }
    }
}
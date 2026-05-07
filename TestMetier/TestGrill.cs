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

        // ════════════════════════════════════════════════════
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

        // ════════════════════════════════════════════════════════
        //  ValeurSelectionnee
        // ════════════════════════════════════════════════════════ 

        [Fact]
        /// <summary>
        /// Setter valeur valide (1 à 9)
        /// </summary>
        public void Grille_ValeurSelectionne()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.ValeurSelectionne = 5;
            Assert.Equal(5, g.ValeurSelectionne);
        }

        [Fact]
        /// <summary>
        /// Setter valeur 1 : valeur minimale valide
        /// </summary>
        public void Grille_ValeurSelectionnee_Min()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.ValeurSelectionne = 1;
            Assert.Equal(1, g.ValeurSelectionne);
        }

        [Fact]
        /// <summary>
        /// Setter valeur 9 : valeur maximale valide
        /// </summary>
        public void Grille_ValeurSelectionnee_Max()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.ValeurSelectionne = 9;
            Assert.Equal(9, g.ValeurSelectionne);
        }

        [Fact]
        /// <summary>
        /// Setter valeur 0 lève EGrilleValeur
        /// </summary>
        public void Grille_ValeurSelectionnee_0()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Throws<EGrilleValeur>(() => g.ValeurSelectionne = 0);
        }

        [Fact]
        /// <summary>
        /// Setter valeur 10 lève EGrilleValeur
        /// </summary>
        public void Grille_ValeurSelectionnee_10()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Throws<EGrilleValeur>(() => g.ValeurSelectionne = 10);
        }

        [Fact]
        /// <summary>
        /// Setter valeur négative lève EGrilleValeur
        /// </summary>
        public void Grille_ValeurSelectionnee_Negative()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Throws<EGrilleValeur>(() => g.ValeurSelectionne = -1);
        }

        // ════════════════════════════════════════════════════════
        //  Curseur
        // ════════════════════════════════════════════════════════
        [Fact]
        /// <summary>
        /// Curseur initialisé à (0,0)
        /// </summary>
        public void Grille_Curseur()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Equal(0, g.Curseur.Ligne);
            Assert.Equal(0, g.Curseur.Colonne);
        }

        [Fact]
        /// <summary>
        /// Déplacer le curseur vers le bas
        /// </summary>
        public void Grille_Curseur_haut()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Curseur.Ligne = 3;
            Assert.Equal(3, g.Curseur.Ligne);
        }

        [Fact]
        /// <summary>
        /// Déplacer le curseur vers la droite
        /// </summary>
        public void Grille_Curseur_Droite()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Curseur.Colonne = 6;
            Assert.Equal(6, g.Curseur.Colonne);
        }

        [Fact]
        /// <summary>
        /// Curseur hors limites (ligne) lève ECoordonnes
        /// </summary>
        public void Grille_Curseur_LigneHorsLimites()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Throws<ECoordonnes>(() => g.Curseur.Ligne = 9);
        }

        [Fact]
        /// <summary>
        /// Curseur hors limites (colonne) lève ECoordonnes
        /// </summary>
        public void Grille_Curseur_ColonneHorsLimites()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            Assert.Throws<ECoordonnes>(() => g.Curseur.Colonne = 9);
        }

        // ════════════════════════════════════════════════════════
        //  MettreValeur
        // ════════════════════════════════════════════════════════

        [Fact]
        /// <summary>
        /// MettreValeur avec bonne valeur sur case non initiale : Affiche passe à true
        /// </summary>
        public void Grille_MettreValeur_BonneValeur_AfficheTrue()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();

            g.Curseur.Ligne = 0;
            g.Curseur.Colonne = 0;
            g.ValeurSelectionne = 8;

            g.MettreValeur();

            Assert.True(g.GetCase(0, 0).Affiche);
        }

        [Fact]
        /// <summary>
        /// MettreValeur avec mauvaise valeur : Affiche reste false
        /// </summary>
        public void Grille_MettreValeur_MauvaiseValeur_AfficheResteFalse()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();

            g.Curseur.Ligne = 0;
            g.Curseur.Colonne = 0;
            g.ValeurSelectionne = 5;

            g.MettreValeur();

            Assert.False(g.GetCase(0, 0).Affiche);
        }

        [Fact]
        /// <summary>
        /// MettreValeur sur une case initiale : Affiche ne change pas
        /// </summary>
        public void Grille_MettreValeur_CaseInitiale_AfficheInchange()
        {
            Grille g = new Grille(9, null, new ChargeurDefaut(9));
            g.Charger();

            g.Curseur.Ligne = 0;
            g.Curseur.Colonne = 5;
            g.ValeurSelectionne = 3;

            bool avantMise = g.GetCase(0, 5).Affiche;
            g.MettreValeur();

            Assert.Equal(avantMise, g.GetCase(0, 5).Affiche);
        }
    }
}
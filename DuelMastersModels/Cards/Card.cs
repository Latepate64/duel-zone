using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Represent a Duel Masters card.
    /// </summary>
    public abstract class Card
    {
        #region Constants
        private const string LightText = "Light";
        private const string WaterText = "Water";
        private const string DarknessText = "Darkness";
        private const string FireText = "Fire";
        private const string NatureText = "Nature";

        private const string CommonText = "Common";
        private const string UncommonText = "Uncommon";
        private const string RareText = "Rare";
        private const string VeryRareText = "Very Rare";
        private const string SuperRareText = "Super Rare";
        private const string NoRarityText = "No Rarity";
        #endregion Constants

        #region Properties
        #region Public
        /// <summary>
        /// Name of the card.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Set in which the card appears.
        /// </summary>
        public string Set { get; private set; }

        /// <summary>
        /// Collector's number of the card.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Civilizations of the card.
        /// </summary>
        public ReadOnlyCivilizationCollection Civilizations { get; }

        /// <summary>
        /// Rarity of the card.
        /// </summary>
        public Rarity Rarity { get; private set; } = Rarity.None;

        /// <summary>
        /// Mana cost of the card.
        /// </summary>
        public int Cost { get; private set; }

        /// <summary>
        /// Text that defines the abilities of the card.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Flavor text of the card.
        /// </summary>
        public string Flavor { get; private set; }

        /// <summary>
        /// Illustrator of the card.
        /// </summary>
        public string Illustrator { get; private set; }

        /// <summary>
        /// Determines whether card is tapped (rotated 90 degrees) or untapped (no rotation).
        /// </summary>
        public bool Tapped { get; internal set; } = false;
        #endregion Public

        #region Internal
        internal bool KnownToOwner { get; set; }
        internal bool KnownToOpponent { get; set; }

        //TODO: remove?
        /*
        /// <summary>
        /// Unique identifier during a game.
        /// </summary>
        internal int GameId { get; private set; }
        */
        #endregion Internal
        #endregion Properties

        #region Fields
        private static readonly Dictionary<string, Rarity> _rarities = new Dictionary<string, Rarity>()
        {
            { CommonText, Rarity.Common },
            { UncommonText, Rarity.Uncommon },
            { RareText, Rarity.Rare },
            { VeryRareText, Rarity.VeryRare },
            { SuperRareText, Rarity.SuperRare },
            { NoRarityText, Rarity.None },
        };
        #endregion Fields

        /// <summary>
        /// Creates a card.
        /// </summary>
        protected Card(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator)
        {
            if (civilizations is null)
            {
                throw new ArgumentNullException(nameof(civilizations));
            }
            Name = name;
            Set = set;
            Id = id;
            Civilizations = GetCivilizations(civilizations);
            Rarity = GetRarity(rarity);
            Cost = cost;
            Flavor = flavor;
            Illustrator = illustrator;
            Text = text;
        }

        #region Private methods
        /// <summary>
        /// Returns a civilization from text.
        /// </summary>
        private static ReadOnlyCivilizationCollection GetCivilizations(Collection<string> civilizationTexts)
        {
            List<Civilization> civilizations = new List<Civilization>();
            if (civilizationTexts.Contains(LightText))
            {
                civilizations.Add(Civilization.Light);
            }
            if (civilizationTexts.Contains(WaterText))
            {
                civilizations.Add(Civilization.Water);
            }
            if (civilizationTexts.Contains(DarknessText))
            {
                civilizations.Add(Civilization.Darkness);
            }
            if (civilizationTexts.Contains(FireText))
            {
                civilizations.Add(Civilization.Fire);
            }
            if (civilizationTexts.Contains(NatureText))
            {
                civilizations.Add(Civilization.Nature);
            }
            if (civilizations.Count == 0)
            {
                throw new ArgumentException("Failed to identify a civilization: " + civilizationTexts);
            }
            return new ReadOnlyCivilizationCollection(civilizations);
        }

        /// <summary>
        /// Returns a rarity from text.
        /// </summary>
        private static Rarity GetRarity(string text)
        {
            return _rarities[text];
        }
        #endregion Private methods
    }
}

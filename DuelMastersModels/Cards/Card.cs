using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Represent a Duel Masters card.
    /// </summary>
    public abstract class Card : ICard
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

        #region Public properties
        /// <summary>
        /// Name of the card.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Set in which the card appears.
        /// </summary>
        public string CardSet { get; private set; }

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

        //TODO: remove
        /*
        /// <summary>
        /// Determines whether card is tapped (rotated 90 degrees) or untapped (no rotation).
        /// </summary>
        public bool Tapped { get; internal set; }

        /// <summary>
        /// Determines whether the owner of the card knows what the card is.
        /// </summary>
        public bool KnownToOwner { get; internal set; }

        /// <summary>
        /// Determines whether the opponent of the owner of the card knows what the card is.
        /// </summary>
        public bool KnownToOpponent { get; internal set; }
        */
        #endregion Public properties

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
        protected Card(string name, string set, string id, int cost, string text, string flavor, string illustrator, Collection<string> civilizations, string rarity)
        {
            if (civilizations is null)
            {
                throw new ArgumentNullException(nameof(civilizations));
            }
            Name = name;
            CardSet = set;
            Id = id;
            Civilizations = GetCivilizations(civilizations);
            Rarity = GetRarity(rarity);
            Cost = cost;
            Flavor = flavor;
            Illustrator = illustrator;
            Text = text;
        }

        /// <summary>
        /// Creates a card.
        /// </summary>
        protected Card(string name, string set, string id, int cost, string text, string flavor, string illustrator, ReadOnlyCivilizationCollection civilizations, Rarity rarity)
        {
            if (civilizations is null)
            {
                throw new ArgumentNullException(nameof(civilizations));
            }
            Name = name;
            CardSet = set;
            Id = id;
            Civilizations = civilizations;
            Rarity = rarity;
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

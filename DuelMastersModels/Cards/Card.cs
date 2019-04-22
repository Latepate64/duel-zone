﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    public enum Rarity { Common, Uncommon, Rare, VeryRare, SuperRare, None };
    public enum Civilization { Light, Water, Darkness, Fire, Nature };

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
        /// <summary>
        /// Unique identifier during a game.
        /// </summary>
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Set { get; set; }
        public string Id { get; set; }
        public Collection<Civilization> Civilizations { get; } = new Collection<Civilization>();
        public Rarity Rarity { get; set; }
        public int Cost { get; set; }
        public string Text { get; set; }
        public string Flavor { get; set; }
        public string Illustrator { get; set; }
        public bool Tapped { get; set; } = false;

        public abstract Card DeepCopy { get; }
        #endregion Properties

        #region Fields
        private static Dictionary<string, Rarity> _rarities = new Dictionary<string, Rarity>()
        {
            { CommonText, Rarity.Common },
            { UncommonText, Rarity.Uncommon },
            { RareText, Rarity.Rare },
            { VeryRareText, Rarity.VeryRare },
            { SuperRareText, Rarity.SuperRare },
            { NoRarityText, Rarity.None },
        };
        #endregion Fields

        protected Card() { }

        /// <summary>
        /// Creates a card.
        /// </summary>
        protected Card(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, int gameId)
        {
            Tapped = false;
            Name = name;
            Set = set;
            Id = id;
            Civilizations = GetCivilizations(civilizations);
            Rarity = GetRarity(rarity);
            Cost = cost;
            Flavor = flavor;
            Illustrator = illustrator;
            Text = text;
            GameId = gameId;
        }

        #region Private methods
        /// <summary>
        /// Returns a civilization from text.
        /// </summary>
        private static Collection<Civilization> GetCivilizations(Collection<string> civilizationTexts)
        {
            if (civilizationTexts == null)
            {
                throw new ArgumentNullException("civilizationTexts");
            }
            else
            {
                var civilizations = new Collection<Civilization>();
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
                return new Collection<Civilization>(civilizations);
            }
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

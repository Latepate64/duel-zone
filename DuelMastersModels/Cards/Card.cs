﻿using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Trigger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    public enum Rarity { Common, Uncommon, Rare, VeryRare, SuperRare, None };
    public enum Civilization { Light, Water, Darkness, Fire, Nature };

    /// <summary>
    /// Represent a Duel Masters card.
    /// </summary>
    public abstract class Card : System.ComponentModel.INotifyPropertyChanged
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
        public int GameId { get; private set; }
        public string Name { get; private set; }
        public string Set { get; private set; }
        public string Id { get; private set; }
        public ReadOnlyCivilizationCollection Civilizations { get; }
        public Rarity Rarity { get; private set; }
        public int Cost { get; private set; }
        public string Text { get; private set; }
        public string Flavor { get; private set; }
        public string Illustrator { get; private set; }
        private bool _tapped;
        public bool Tapped
        {
            get => _tapped;
            set
            {
                if (value != _tapped)
                {
                    _tapped = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        public AbilityCollection Abilities { get; } = new AbilityCollection();
        public ReadOnlyStaticAbilityCollection StaticAbilities => new ReadOnlyStaticAbilityCollection(Abilities.Where(a => a is StaticAbility).Cast<StaticAbility>());
        public ReadOnlyTriggerAbilityCollection TriggerAbilities => new ReadOnlyTriggerAbilityCollection(Abilities.Where(a => a is TriggerAbility).Cast<TriggerAbility>());

        public bool KnownToOwner { get; set; }
        public bool KnownToOpponent { get; set; }

        private bool _knownToPlayerWithPriority;
        public bool KnownToPlayerWithPriority
        {
            get => _knownToPlayerWithPriority;
            set
            {
                _knownToPlayerWithPriority = value;
                NotifyPropertyChanged();
            }
        }

        private bool _knownToPlayerWithoutPriority;
        public bool KnownToPlayerWithoutPriority
        {
            get => _knownToPlayerWithoutPriority;
            set
            {
                _knownToPlayerWithoutPriority = value;
                NotifyPropertyChanged();
            }
        }
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

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

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
        private static ReadOnlyCivilizationCollection GetCivilizations(Collection<string> civilizationTexts)
        {
            if (civilizationTexts == null)
            {
                throw new ArgumentNullException("civilizationTexts");
            }
            else
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

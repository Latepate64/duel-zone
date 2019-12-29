using DuelMastersModels.Abilities;
using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Trigger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// Represent a Duel Masters card.
    /// </summary>
    public abstract class Card : INotifyPropertyChanged
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
        public Rarity Rarity { get; private set; }

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
        public bool Tapped { get; set; }

        /// <summary>
        /// An ability can be a characteristic an card has that lets it affect the game. A card's abilities are defined by its rules text or by the effect that created it.
        /// </summary>
        internal AbilityCollection Abilities { get; } = new AbilityCollection();
        public ReadOnlyStaticAbilityCollection StaticAbilities => new ReadOnlyStaticAbilityCollection(Abilities.Where(a => a is StaticAbility).Cast<StaticAbility>());
        public ReadOnlyTriggerAbilityCollection TriggerAbilities => new ReadOnlyTriggerAbilityCollection(Abilities.Where(a => a is TriggerAbility).Cast<TriggerAbility>());

        private bool _knownToOwner;
        public bool KnownToOwner
        {
            get => _knownToOwner;
            set
            {
                _knownToOwner = value;
                NotifyPropertyChanged();
            }
        }

        private bool _knownToOpponent;
        public bool KnownToOpponent
        {
            get => _knownToOpponent;
            set
            {
                _knownToOpponent = value;
                NotifyPropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

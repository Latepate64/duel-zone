using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersJson
{
    /// <summary>
    /// A template for a card parsed from json-file.
    /// </summary>
    public class JsonCard
    {
        #region Properties
        /// <summary>
        /// Name of the card. (eg. Aqua Hulcus)
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Set in which the card appears. (eg. DM-01 Base Set)
        /// </summary>
        public string Set { get; private set; }

        /// <summary>
        /// Identifier of the card. (eg. 23/110)
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Civilizations of the card. Supported values for civilization are Light, Water, Darkness, Fire and Nature. 
        /// </summary>
        public Collection<string> Civilizations { get; private set; }

        /// <summary>
        /// Rarity of the card. Supported values for rarity are Common, Uncommon, Rare, Very Rare and Super Rare.
        /// </summary>
        public string Rarity { get; private set; }

        /// <summary>
        /// Type of the card. Supported values are Creature, Spell, Evolution Creature and Cross Gear.
        /// </summary>
        public string CardType { get; private set; }

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
        /// Illustator of the card.
        /// </summary>
        public string Illustrator { get; private set; }

        /// <summary>
        /// This property is used if the card is of type "Creature". Contains the races of the creature. (eg. Liquid People)
        /// </summary>
        public Collection<string> Races { get; private set; }

        /// <summary>
        /// This property is used if the card is of type "Creature". Defines the power of the creature. (eg. 2000)
        /// </summary>
        public string Power { get; private set; }

        /// <summary>
        /// Returns a copy of the card.
        /// </summary>
        public JsonCard DeepCopy
        {
            get
            {
                JsonCard card = new JsonCard()
                {
                    CardType = CardType,
                    Cost = Cost,
                    Flavor = Flavor,
                    Id = Id,
                    Illustrator = Illustrator,
                    Name = Name,
                    Power = Power,
                    Rarity = Rarity,
                    Set = Set,
                    Text = Text,
                };
                if (Civilizations != null)
                {
                    card.Civilizations = new Collection<string>(Civilizations);
                }
                if (Races != null)
                {
                    card.Races = new Collection<string>(Races);
                }
                return card;
            }
        }
        #endregion Properties

        /// <summary>
        /// Creates a JsonCard.
        /// </summary>
        [JsonConstructor]
        public JsonCard(string name, string set, string id, string civilization, Collection<string> civilizations, string type, string rarity, int cost, string text, string flavor, string illustrator, string race, Collection<string> races, string power)
        {
            Name = name;
            Set = set;
            Id = id;
            if (civilizations != null)
            {
                Civilizations = civilizations;
            }
            else
            {
                Civilizations = new Collection<string>(new List<string>() { civilization });
            }
            CardType = type;
            Rarity = rarity;
            Cost = cost;
            Text = text;
            Flavor = flavor;
            Illustrator = illustrator;
            if (races != null)
            {
                Races = new Collection<string>(races);
            }
            else if (race != null)
            {
                Races = new Collection<string>(new List<string>() { race });
            }
            Power = power;
        }

        private JsonCard() { }
    }
}

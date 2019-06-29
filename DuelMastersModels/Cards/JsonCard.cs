using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    /// <summary>
    /// A template for a card parsed from JSON.
    /// </summary>
    public class JsonCard
    {
        public string Name { get; private set; }
        public string Set { get; private set; }
        public string Id { get; private set; }
        public Collection<string> Civilizations { get; private set; }
        public string Rarity { get; private set; }
        public string CardType { get; private set; }
        public int Cost { get; private set; }
        public string Text { get; private set; }
        public string Flavor { get; private set; }
        public string Illustrator { get; private set; }
        public Collection<string> Races { get; private set; }
        public string Power { get; private set; }

        public JsonCard() { }

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
    }
}

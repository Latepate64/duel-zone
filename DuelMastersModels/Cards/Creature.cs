using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    public class Creature : Card
    {
        public int Power { get; }
        public Collection<string> Races { get; }
        public bool SummoningSickness { get; set; } = true;

        /// <summary>
        /// Creates a creature.
        /// </summary>
        public Creature(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, int gameId, int power, Collection<string> races) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator, gameId)
        {
            Power = power;
            Races = races;
        }
    }
}

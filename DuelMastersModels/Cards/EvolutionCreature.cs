using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    public class EvolutionCreature : Creature
    {
        public override Card DeepCopy
        {
            get
            {
                EvolutionCreature creature = new EvolutionCreature()
                {
                    Cost = Cost,
                    Flavor = Flavor,
                    GameId = GameId,
                    Id = Id,
                    Illustrator = Illustrator,
                    Name = Name,
                    Power = Power,
                    Rarity = Rarity,
                    Set = Set,
                    SummoningSickness = SummoningSickness,
                    Tapped = Tapped,
                    Text = Text
                };
                foreach (Civilization civilization in Civilizations)
                {
                    creature.Civilizations.Add(civilization);
                }
                foreach (string race in Races)
                {
                    creature.Races.Add(race);
                }
                return creature;
            }
        }

        public EvolutionCreature() : base()
        {
        }

        /// <summary>
        /// Creates an evolution creature.
        /// </summary>
        public EvolutionCreature(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, int gameId, string power, Collection<string> races) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator, gameId, power, races)
        {
        }
    }
}

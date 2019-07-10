using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    public class Spell : Card
    {
        public override Card DeepCopy
        {
            get
            {
                Spell spell = new Spell()
                {
                    Cost = Cost,
                    Flavor = Flavor,
                    GameId = GameId,
                    Id = Id,
                    Illustrator = Illustrator,
                    Name = Name,
                    Rarity = Rarity,
                    Set = Set,
                    Tapped = Tapped,
                    Text = Text
                };
                foreach (Civilization civilization in Civilizations)
                {
                    spell.Civilizations.Add(civilization);
                }
                return spell;
            }
        }

        public Spell() : base()
        {
        }

        /// <summary>
        /// Creates a spell.
        /// </summary>
        public Spell(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, int gameId) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator, gameId)
        {
        }
    }
}

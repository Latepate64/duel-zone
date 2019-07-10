using System.Collections.ObjectModel;

namespace DuelMastersModels.Cards
{
    public class CrossGear : Card
    {
        public override Card DeepCopy
        {
            get
            {
                CrossGear crossGear = new CrossGear()
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
                    crossGear.Civilizations.Add(civilization);
                }
                return crossGear;
            }
        }

        public CrossGear() : base()
        {
        }

        /// <summary>
        /// Creates a cross gear.
        /// </summary>
        public CrossGear(string name, string set, string id, Collection<string> civilizations, string rarity, int cost, string text, string flavor, string illustrator, int gameId) : base(name, set, id, civilizations, rarity, cost, text, flavor, illustrator, gameId)
        {
        }
    }
}

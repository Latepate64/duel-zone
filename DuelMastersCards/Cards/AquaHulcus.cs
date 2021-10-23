using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class AquaHulcus : Creature
    {
        public AquaHulcus() : base("Aqua Hulcus", 3, Civilization.Water, 2000, Subtype.LiquidPeople)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardResolvable()));
        }
    }
}

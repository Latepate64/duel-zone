using DuelMastersCards.Resolvables;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class AquaSniper : Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, Civilization.Water, 5000, Subtype.LiquidPeople)
        {
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable(2)));
        }
    }
}

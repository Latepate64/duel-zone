using DuelMastersCards.Resolvables;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, Civilization.Water, 1000, Subtype.LiquidPeople)
        {
            Abilities.Add(new BlockerAbility());
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable()));
        }
    }
}

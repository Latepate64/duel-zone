using DuelMastersCards.OneShotEffects;
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
            // When you put this creature into the battle zone, you may choose a creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(0, 1)));
        }
    }
}

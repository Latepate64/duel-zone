using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    public class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, Common.Civilization.Water, 1000, Common.Subtype.LiquidPeople)
        {
            Abilities.Add(new BlockerAbility());
            // When you put this creature into the battle zone, you may choose a creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(0, 1, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}

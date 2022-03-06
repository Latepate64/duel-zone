using Cards.OneShotEffects;
using Cards.StaticAbilities;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class AquaBouncer : Creature
    {
        public AquaBouncer() : base("Aqua Bouncer", 6, 1000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            // When you put this creature into the battle zone, you may choose a creature in the battle zone and return it to its owner's hand.
            AddAbilities(new BlockerAbility(), new PutIntoPlayAbility(new BounceEffect(0, 1, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}

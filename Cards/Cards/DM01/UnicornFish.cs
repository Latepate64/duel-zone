using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class UnicornFish : Creature
    {
        public UnicornFish() : base("Unicorn Fish", 4, Common.Civilization.Water, 1000, Common.Subtype.Fish)
        {
            // When you put this creature into the battle zone, you may choose 1 creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new PutIntoPlayAbility(new BounceEffect(0, 1, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}

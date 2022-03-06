using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM05
{
    class AquaSurfer : Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, 2000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, you may choose a creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new PutIntoPlayAbility(new BounceEffect(0, 1, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}

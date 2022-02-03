using Cards.OneShotEffects;
using Cards.TriggeredAbilities;
using Common;

namespace Cards.Cards.DM05
{
    public class AquaSurfer : Creature
    {
        public AquaSurfer() : base("Aqua Surfer", 6, Common.Civilization.Water, 2000, Common.Subtype.LiquidPeople)
        {
            ShieldTrigger = true;
            // When you put this creature into the battle zone, you may choose a creature in the battle zone and return it to its owner's hand.
            Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BounceEffect(0, 1, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}

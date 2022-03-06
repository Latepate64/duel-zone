using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM01
{
    class AquaSniper : Creature
    {
        public AquaSniper() : base("Aqua Sniper", 8, 5000, Common.Subtype.LiquidPeople, Common.Civilization.Water)
        {
            // When you put this creature into the battle zone, choose up to 2 creatures in the battle zone and return them to their owners' hands.
            AddAbilities(new PutIntoPlayAbility(new BounceEffect(0, 2, new CardFilters.BattleZoneChoosableCreatureFilter())));
        }
    }
}

using Common;

namespace Cards.Cards.DM02
{
    class CrystalPaladin : EvolutionCreature
    {
        public CrystalPaladin() : base("Crystal Paladin", 4, 5000, Subtype.LiquidPeople, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsPutIntoTheBattleZoneAbility(new OneShotEffects.BounceAreaOfEffect(new CardFilters.BattleZoneBlockerCreatureFilter())));
        }
    }
}

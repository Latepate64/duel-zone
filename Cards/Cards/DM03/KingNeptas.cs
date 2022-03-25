using Common;

namespace Cards.Cards.DM03
{
    class KingNeptas : Creature
    {
        public KingNeptas() : base("King Neptas", 6, 5000, Subtype.Leviathan, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.BounceEffect(0, 1, new CardFilters.BattleZoneChoosableMaxPowerCreatureFilter(2000))));
        }
    }
}

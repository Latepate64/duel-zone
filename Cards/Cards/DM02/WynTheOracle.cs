using Common;

namespace Cards.Cards.DM02
{
    class WynTheOracle : Creature
    {
        public WynTheOracle() : base("Wyn, the Oracle", 2, 1500, Subtype.LightBringer, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.LookEffect(new CardFilters.OpponentsShieldZoneCardFilter(), 0, 1, true)));
        }
    }
}

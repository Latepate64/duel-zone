using Common;

namespace Cards.Cards.DM02
{
    class LarbaGeerTheImmaculate : EvolutionCreature
    {
        public LarbaGeerTheImmaculate() : base("Larba Geer, the Immaculate", 3, 5000, Subtype.Guardian, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.TapAreaOfEffect(new CardFilters.OpponentsBattleZoneBlockerCreatureFilter())));
        }
    }
}

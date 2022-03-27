using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class LarbaGeerTheImmaculate : EvolutionCreature
    {
        public LarbaGeerTheImmaculate() : base("Larba Geer, the Immaculate", 3, 5000, Subtype.Guardian, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new LarbaGeerTheImmaculateEffect()));
        }
    }

    class LarbaGeerTheImmaculateEffect : OneShotEffects.TapAreaOfEffect
    {
        public LarbaGeerTheImmaculateEffect() : base(new CardFilters.OpponentsBattleZoneBlockerCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new LarbaGeerTheImmaculateEffect();
        }

        public override string ToString()
        {
            return "Tap all your opponent's creatures in the battle zone that have \"blocker.\"";
        }
    }
}

using Abilities.Triggered;
using Abilities.Triggered;
using Effects.Continuous;

namespace Cards.Cards.DM05
{
    class SyforceAuroraElemental : Engine.Creature
    {
        public SyforceAuroraElemental() : base("Syforce, Aurora Elemental", 7, 7000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

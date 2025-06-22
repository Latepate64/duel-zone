using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM05
{
    sealed class SyforceAuroraElemental : Engine.Creature
    {
        public SyforceAuroraElemental() : base("Syforce, Aurora Elemental", 7, 7000, Interfaces.Race.AngelCommand, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

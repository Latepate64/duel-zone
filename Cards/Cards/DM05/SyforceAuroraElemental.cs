using Cards.ContinuousEffects;

namespace Cards.Cards.DM05
{
    class SyforceAuroraElemental : Creature
    {
        public SyforceAuroraElemental() : base("Syforce, Aurora Elemental", 7, 7000, Engine.Race.AngelCommand, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.YouMayReturnSpellFromYourManaZoneToYourHandEffect());
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

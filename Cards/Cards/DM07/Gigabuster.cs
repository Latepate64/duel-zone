using Cards.ContinuousEffects;

namespace Cards.Cards.DM07
{
    class Gigabuster : Creature
    {
        public Gigabuster() : base("Gigabuster", 5, 5000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}

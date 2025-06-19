using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM07
{
    class Gigabuster : Creature
    {
        public Gigabuster() : base("Gigabuster", 5, 5000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}

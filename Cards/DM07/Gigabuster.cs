using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM07
{
    class Gigabuster : Engine.Creature
    {
        public Gigabuster() : base("Gigabuster", 5, 5000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}

using Abilities.Static;
using ContinuousEffects.CannotAttack;
using TriggeredAbilities;

namespace Cards.DM07
{
    sealed class Gigabuster : Creature
    {
        public Gigabuster() : base("Gigabuster", 5, 5000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ShieldRecoveryCannotUseShieldTriggerEffect()));
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }
    }
}

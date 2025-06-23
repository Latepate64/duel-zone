using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM09
{
    sealed class JilWarkaTimeGuardian : Creature
    {
        public JilWarkaTimeGuardian() : base("Jil Warka, Time Guardian", 3, 2000, Interfaces.Race.Guardian, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect()));
        }
    }
}

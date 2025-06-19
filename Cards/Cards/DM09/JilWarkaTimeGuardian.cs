using Cards.ContinuousEffects;

namespace Cards.Cards.DM09
{
    class JilWarkaTimeGuardian : Creature
    {
        public JilWarkaTimeGuardian() : base("Jil Warka, Time Guardian", 3, 2000, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect());
        }
    }
}

using Common;

namespace Cards.Cards.DM09
{
    class JilWarkaTimeGuardian : Creature
    {
        public JilWarkaTimeGuardian() : base("Jil Warka, Time Guardian", 3, 2000, Engine.Subtype.Guardian, Civilization.Light)
        {
            AddBlockerAbility();
            AddThisCreatureCannotAttackPlayersAbility();
            AddWhenThisCreatureIsDestroyedAbility(new OneShotEffects.ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(2));
        }
    }
}

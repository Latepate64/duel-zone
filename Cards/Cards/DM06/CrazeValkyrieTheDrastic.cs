namespace Cards.Cards.DM06
{
    class CrazeValkyrieTheDrastic : EvolutionCreature
    {
        public CrazeValkyrieTheDrastic() : base("Craze Valkyrie, the Drastic", 6, 7500, Engine.Race.Initiate, Engine.Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.ChooseUpToTwoOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect());
            AddDoubleBreakerAbility();
        }
    }
}
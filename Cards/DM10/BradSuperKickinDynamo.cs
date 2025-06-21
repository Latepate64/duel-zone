namespace Cards.DM10
{
    class BradSuperKickinDynamo : SilentSkillCreature
    {
        public BradSuperKickinDynamo() : base("Brad, Super Kickin' Dynamo", 3, 2000, Interfaces.Race.Human, Interfaces.Civilization.Fire)
        {
            AddSilentSkillAbility(new OneShotEffects.DestroyOneOfYourOpponentsCreaturesThatHasBlockerEffect());
        }
    }
}

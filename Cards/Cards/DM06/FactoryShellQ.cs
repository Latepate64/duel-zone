namespace Cards.Cards.DM06
{
    class FactoryShellQ : Creature
    {
        public FactoryShellQ() : base("Factory Shell Q", 6, 2000, Engine.Race.Survivor, Engine.Race.ColonyBeetle, Engine.Civilization.Nature)
        {
            AddSurvivorAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchRaceCreatureEffect(Engine.Race.Survivor)));
        }
    }
}

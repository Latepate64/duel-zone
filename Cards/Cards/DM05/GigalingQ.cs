namespace Cards.Cards.DM05
{
    class GigalingQ : Creature
    {
        public GigalingQ() : base("Gigaling Q", 5, 2000, Engine.Race.Survivor, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddSurvivorAbility(new ContinuousEffects.ThisCreatureHasSlayerEffect());
        }
    }
}

namespace Cards.DM10
{
    class ClearloGraceEnforcer : Engine.Creature
    {
        public ClearloGraceEnforcer() : base("Clearlo, Grace Enforcer", 3, 1000, Engine.Race.Berserker, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(1000));
        }
    }
}

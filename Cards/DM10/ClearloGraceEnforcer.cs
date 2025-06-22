namespace Cards.DM10
{
    sealed class ClearloGraceEnforcer : Engine.Creature
    {
        public ClearloGraceEnforcer() : base("Clearlo, Grace Enforcer", 3, 1000, Interfaces.Race.Berserker, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ContinuousEffects.ThisCreatureGetsPowerForEachOfYourOtherUntappedCreatures(1000));
        }
    }
}

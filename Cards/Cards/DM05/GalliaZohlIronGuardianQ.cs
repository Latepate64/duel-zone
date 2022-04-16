namespace Cards.Cards.DM05
{
    class GalliaZohlIronGuardianQ : Creature
    {
        public GalliaZohlIronGuardianQ() : base("Gallia Zohl, Iron Guardian Q", 5, 2000, Engine.Race.Survivor, Engine.Race.Guardian, Engine.Civilization.Light)
        {
            AddSurvivorAbility(new ContinuousEffects.ThisCreatureHasBlockerEffect());
        }
    }
}

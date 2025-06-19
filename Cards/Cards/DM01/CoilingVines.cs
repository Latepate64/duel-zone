namespace Cards.Cards.DM01
{
    class CoilingVines : Engine.Creature
    {
        public CoilingVines() : base("Coiling Vines", 4, 3000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

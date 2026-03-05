namespace Cards.DM01
{
    sealed class CoilingVines : Creature
    {
        public CoilingVines() : base("Coiling Vines", 4, 3000, Interfaces.Race.TreeFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

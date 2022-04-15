namespace Cards.Cards.DM01
{
    class CoilingVines : Creature
    {
        public CoilingVines() : base("Coiling Vines", 4, 3000, Engine.Subtype.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

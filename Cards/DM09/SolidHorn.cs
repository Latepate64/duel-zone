namespace Cards.DM09
{
    sealed class SolidHorn : Engine.Creature
    {
        public SolidHorn() : base("Solid Horn", 6, 5000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

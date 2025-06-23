namespace Cards.DM10
{
    sealed class ShamanBroccoli : Creature
    {
        public ShamanBroccoli() : base("Shaman Broccoli", 2, 1000, Interfaces.Race.WildVeggies, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

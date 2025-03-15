namespace Cards.Cards.DM10
{
    public class ShamanBroccoli : Creature
    {
        public ShamanBroccoli() : base("Shaman Broccoli", 2, 1000, Engine.Race.WildVeggies, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

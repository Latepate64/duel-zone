namespace Cards.Cards.DM09
{
    class SolidHorn : Engine.Creature
    {
        public SolidHorn() : base("Solid Horn", 6, 5000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

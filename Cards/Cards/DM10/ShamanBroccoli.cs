using Common;

namespace Cards.Cards.DM10
{
    class ShamanBroccoli : Creature
    {
        public ShamanBroccoli() : base("Shaman Broccoli", 2, 1000, Engine.Subtype.WildVeggies, Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

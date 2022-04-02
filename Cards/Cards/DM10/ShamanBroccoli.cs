using Common;

namespace Cards.Cards.DM10
{
    class ShamanBroccoli : Creature
    {
        public ShamanBroccoli() : base("Shaman Broccoli", 2, 1000, Subtype.WildVeggies, Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

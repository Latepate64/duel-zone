using Common;

namespace Cards.Cards.DM09
{
    class SolidHorn : Creature
    {
        public SolidHorn() : base("Solid Horn", 6, 5000, Subtype.BeastFolk, Civilization.Nature)
        {
            AddStaticAbilities(new ContinuousEffects.WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

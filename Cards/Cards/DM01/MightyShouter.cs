using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, 2000, Engine.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

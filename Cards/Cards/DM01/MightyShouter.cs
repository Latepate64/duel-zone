using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, 2000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

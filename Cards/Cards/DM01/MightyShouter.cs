using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class MightyShouter : Engine.Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, 2000, Engine.Race.BeastFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

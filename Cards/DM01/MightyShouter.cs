using ContinuousEffects;

namespace Cards.DM01
{
    sealed class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, 2000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

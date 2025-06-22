using ContinuousEffects;

namespace Cards.DM01
{
    sealed class MightyShouter : Engine.Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, 2000, Interfaces.Race.BeastFolk, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

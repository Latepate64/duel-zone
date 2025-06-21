using ContinuousEffects;

namespace Cards.DM01
{
    class RedEyeScorpion : Engine.Creature
    {
        public RedEyeScorpion() : base("Red-Eye Scorpion", 5, 4000, Interfaces.Race.GiantInsect, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

using Cards.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class RedEyeScorpion : Creature
    {
        public RedEyeScorpion() : base("Red-Eye Scorpion", 5, 4000, Engine.Race.GiantInsect, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
        }
    }
}

using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class RedEyeScorpion : Creature
    {
        public RedEyeScorpion() : base("Red-Eye Scorpion", 5, Common.Civilization.Nature, 4000, Common.Subtype.GiantInsect)
        {
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}

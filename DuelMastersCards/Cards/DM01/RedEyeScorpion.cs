using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class RedEyeScorpion : Creature
    {
        public RedEyeScorpion() : base("Red-Eye Scorpion", 5, Civilization.Nature, 4000, Subtype.GiantInsect)
        {
            Abilities.Add(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}

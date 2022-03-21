using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class MightyShouter : Creature
    {
        public MightyShouter() : base("Mighty Shouter", 3, 2000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            AddAbilities(new WhenThisCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadAbility());
        }
    }
}

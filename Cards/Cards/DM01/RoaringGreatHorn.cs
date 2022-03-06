using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class RoaringGreatHorn : Creature
    {
        public RoaringGreatHorn() : base("Roaring Great-Horn", 7, 8000, Common.Subtype.HornedBeast, Common.Civilization.Nature)
        {
            AddAbilities(new PowerAttackerAbility(2000));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}

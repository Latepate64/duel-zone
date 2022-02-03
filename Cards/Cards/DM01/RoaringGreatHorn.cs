using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class RoaringGreatHorn : Creature
    {
        public RoaringGreatHorn() : base("Roaring Great-Horn", 7, Common.Civilization.Nature, 8000, Common.Subtype.HornedBeast)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}

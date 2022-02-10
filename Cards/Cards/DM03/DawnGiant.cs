using Cards.StaticAbilities;

namespace Cards.Cards.DM03
{
    class DawnGiant : Creature
    {
        public DawnGiant() : base("Dawn Giant", 7, Common.Civilization.Nature, 11000, Common.Subtype.Giant)
        {
            Abilities.Add(new CannotAttackCreaturesAbility());
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}

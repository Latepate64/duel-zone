using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards
{
    public class RoaringGreatHorn : Creature
    {
        public RoaringGreatHorn() : base("Roaring Great-Horn", 7, Civilization.Nature, 8000, Subtype.BeastFolk)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}

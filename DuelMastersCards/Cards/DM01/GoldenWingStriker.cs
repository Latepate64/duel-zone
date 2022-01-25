using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    class GoldenWingStriker : Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, Civilization.Nature, 2000, Subtype.BeastFolk)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}

using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM01
{
    class GoldenWingStriker : Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, Civilization.Nature, 2000, Subtype.BeastFolk)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}

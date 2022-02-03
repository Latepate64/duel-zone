using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class GoldenWingStriker : Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, Common.Civilization.Nature, 2000, Common.Subtype.BeastFolk)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}

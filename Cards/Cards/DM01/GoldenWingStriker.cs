using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class GoldenWingStriker : Creature
    {
        public GoldenWingStriker() : base("Golden Wing Striker", 3, 2000, Common.Subtype.BeastFolk, Common.Civilization.Nature)
        {
            Abilities.Add(new PowerAttackerAbility(2000));
        }
    }
}

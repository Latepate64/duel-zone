using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class StampedingLonghorn : Creature
    {
        public StampedingLonghorn() : base("Stampeding Longhorn", 5, 4000, Common.Subtype.HornedBeast, Common.Civilization.Nature)
        {
            AddAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerAbility(3000));
        }
    }
}

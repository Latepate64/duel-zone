using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM06
{
    class ClobberTotem : Creature
    {
        public ClobberTotem() : base("Clobber Totem", 6, 4000, Subtype.MysteryTotem, Civilization.Nature)
        {
            AddAbilities(new PowerAttackerAbility(2000), new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerAbility(5000), new DoubleBreakerAbility());
        }
    }
}

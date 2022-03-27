using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AncientGiant : Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Subtype.Giant, Civilization.Nature)
        {
            AddAbilities(new ThisCreatureCannotBeBlockedByCivilizationCreaturesAbility(Civilization.Darkness), new DoubleBreakerAbility());
        }
    }
}

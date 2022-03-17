using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AncientGiant : Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Subtype.Giant, Civilization.Nature)
        {
            // This creature can't be blocked by darkness creatures.
            AddAbilities(new UnblockableAbility(new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(Civilization.Darkness)), new DoubleBreakerAbility());
        }
    }
}

using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AncientGiant : Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Subtype.Giant, Civilization.Nature)
        {
            // This creature can't be blocked by darkness creatures.
            var filter = new CardFilters.OpponentsBattleZoneCreatureFilter();
            filter.Civilizations.Add(Civilization.Darkness);
            AddAbilities(new UnblockableAbility(filter), new DoubleBreakerAbility());
        }
    }
}

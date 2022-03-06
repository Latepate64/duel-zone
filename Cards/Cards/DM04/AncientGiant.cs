using Cards.StaticAbilities;
using Common;

namespace Cards.Cards.DM04
{
    class AncientGiant : Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, Civilization.Nature, 9000, Subtype.Giant)
        {
            // This creature can't be blocked by darkness creatures.
            var filter = new CardFilters.OpponentsBattleZoneCreatureFilter();
            filter.Civilizations.Add(Civilization.Darkness);
            AddAbilities(new UnblockableAbility(filter), new DoubleBreakerAbility());
        }
    }
}

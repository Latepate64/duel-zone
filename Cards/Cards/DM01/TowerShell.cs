using Cards.CardFilters;
using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    class TowerShell : Creature
    {
        public TowerShell() : base("Tower Shell", 6, 5000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(4000)));
        }
    }
}

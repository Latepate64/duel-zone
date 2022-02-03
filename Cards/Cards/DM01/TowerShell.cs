using Cards.CardFilters;
using Cards.StaticAbilities;

namespace Cards.Cards.DM01
{
    public class TowerShell : Creature
    {
        public TowerShell() : base("Tower Shell", 6, Common.Civilization.Nature, 5000, Common.Subtype.ColonyBeetle)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(4000)));
        }
    }
}

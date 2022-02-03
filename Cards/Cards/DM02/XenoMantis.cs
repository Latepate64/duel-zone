using Cards.CardFilters;
using Cards.StaticAbilities;

namespace Cards.Cards.DM02
{
    class XenoMantis : Creature
    {
        public XenoMantis() : base("Xeno Mantis", 7, Common.Civilization.Nature, 6000, Common.Subtype.GiantInsect)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(5000)));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}

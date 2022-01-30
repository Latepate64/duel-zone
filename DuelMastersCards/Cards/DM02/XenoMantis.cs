using Cards.CardFilters;
using Cards.StaticAbilities;
using DuelMastersModels;

namespace Cards.Cards.DM02
{
    class XenoMantis : Creature
    {
        public XenoMantis() : base("Xeno Mantis", 7, Civilization.Nature, 6000, Subtype.GiantInsect)
        {
            Abilities.Add(new UnblockableAbility(new BattleZoneMaxPowerCreatureFilter(5000)));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}

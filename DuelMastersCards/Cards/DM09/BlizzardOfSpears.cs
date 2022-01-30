using Cards.CardFilters;
using Cards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace Cards.Cards.DM09
{
    public class BlizzardOfSpears : Spell
    {
        public BlizzardOfSpears() : base("Blizzard of Spears", 6, Civilization.Fire)
        {
            // Destroy all creatures that have power 4000 or less.
            Abilities.Add(new SpellAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, new BattleZoneMaxPowerCreatureFilter(4000))));
        }
    }
}

using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine.Abilities;
using Engine.Zones;

namespace Cards.Cards.DM09
{
    public class BlizzardOfSpears : Spell
    {
        public BlizzardOfSpears() : base("Blizzard of Spears", 6, Common.Civilization.Fire)
        {
            // Destroy all creatures that have power 4000 or less.
            Abilities.Add(new SpellAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, new BattleZoneMaxPowerCreatureFilter(4000))));
        }
    }
}

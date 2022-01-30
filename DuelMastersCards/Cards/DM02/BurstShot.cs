using Cards.CardFilters;
using Cards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace Cards.Cards.DM02
{
    public class BurstShot : Spell
    {
        public BurstShot() : base("Burst Shot", 6, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy all creatures that have power 2000 or less.
            Abilities.Add(new SpellAbility(new CardMovingAreaOfEffect(ZoneType.BattleZone, ZoneType.Graveyard, new BattleZoneMaxPowerCreatureFilter(2000))));
        }
    }
}

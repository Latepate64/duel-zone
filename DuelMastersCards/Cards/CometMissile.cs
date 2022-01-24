using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class CometMissile : Spell
    {
        public CometMissile() : base("Comet Missile", 1, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy one of your opponent's creatures that has "blocker" and power 6000 or less.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(new OpponentsBattleZoneChoosableMaxPowerBlockerCreatureFilter(6000), 1, 1, true, ZoneType.BattleZone, ZoneType.Graveyard)));
        }
    }
}

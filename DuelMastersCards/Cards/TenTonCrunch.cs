using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class TenTonCrunch : Spell
    {
        public TenTonCrunch() : base("Ten-Ton Crunch", 4, Civilization.Fire)
        {
            ShieldTrigger = true;
            // Destroy one of your opponent's creatures that has power 3000 or less.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(ZoneType.BattleZone, ZoneType.Graveyard, new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(3000), 1, 1, true)));
        }
    }
}

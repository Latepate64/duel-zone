using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class VolcanoCharger : Spell
    {
        public VolcanoCharger() : base("Volcano Charger", 4, Civilization.Fire)
        {
            // Destroy one of your opponent's creatures that has power 2000 or less.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(2000), 1, 1, true, ZoneType.BattleZone, ZoneType.Graveyard)));
            Abilities.Add(new ChargerAbility());
        }
    }
}

using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class SpasticMissile : Spell
    {
        public SpasticMissile() : base("Spastic Missile", 3, Civilization.Fire)
        {
            // Destroy one of your opponent's creatures that has power 3000 or less.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(3000), 1, 1, true, ZoneType.BattleZone, ZoneType.Graveyard)));
        }
    }
}

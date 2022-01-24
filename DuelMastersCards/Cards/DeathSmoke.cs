using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    class DeathSmoke : Spell
    {
        public DeathSmoke() : base("Death Smoke", 4, Civilization.Darkness)
        {
            // Destroy 1 of your opponent's untapped creatures.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(new OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true, ZoneType.BattleZone, ZoneType.Graveyard)));
        }
    }
}

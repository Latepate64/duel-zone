using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Zones;

namespace DuelMastersCards.Cards
{
    public class VolcanicArrows : Spell
    {
        public VolcanicArrows() : base("Volcanic Arrows", 2, Civilization.Fire)
        {
            ShieldTrigger = true;

            // Destroy a creature that has power 6000 or less.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(ZoneType.BattleZone, ZoneType.Graveyard, new OpponentsBattleZoneChoosableMaxPowerCreatureFilter(6000), 1, 1, true)));

            // Choose one of your shields and put it into your graveyard.
            Abilities.Add(new SpellAbility(new CardMovingChoiceEffect(ZoneType.ShieldZone, ZoneType.Graveyard, new OwnersShieldZoneCardFilter(), 1, 1, true)));
        }
    }
}

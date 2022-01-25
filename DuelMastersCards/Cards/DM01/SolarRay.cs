using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards.DM01
{
    class SolarRay : Spell
    {
        public SolarRay() : base("Solar Ray", 2, Civilization.Light)
        {
            ShieldTrigger = true;

            // Choose 1 of your opponent's creatures in the battle zone and tap it.
            Abilities.Add(new SpellAbility(new TapChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }
}

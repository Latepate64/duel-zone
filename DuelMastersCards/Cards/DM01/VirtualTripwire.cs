using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards.DM01
{
    class VirtualTripwire : Spell
    {
        public VirtualTripwire() : base("Virtual Tripwire", 3, Civilization.Water)
        {
            // Choose 1 of your opponent's creatures in the battle zone and tap it.
            Abilities.Add(new SpellAbility(new TapChoiceEffect(new OpponentsBattleZoneChoosableCreatureFilter(), 1, 1, true)));
        }
    }
}

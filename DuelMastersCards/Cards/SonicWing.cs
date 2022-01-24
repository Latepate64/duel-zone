using DuelMastersCards.CardFilters;
using DuelMastersCards.OneShotEffects;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;

namespace DuelMastersCards.Cards
{
    class SonicWing : Spell
    {
        public SonicWing() : base("Sonic Wing", 3, Civilization.Light)
        {
            // Choose one of your creatures in the battle zone. It can't be blocked this turn.
            Abilities.Add(new SpellAbility(new CreateContinuousEffectChoiceEffect(new OwnersBattleZoneCreatureFilter(), 1, 1, true, new UnblockableEffect(null, new DuelMastersModels.Durations.UntilTheEndOfTheTurn(), new AnyFilter()))));
        }
    }
}

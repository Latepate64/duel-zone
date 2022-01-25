using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;

namespace DuelMastersCards.Cards
{
    class ChaosStrike : Spell
    {
        public ChaosStrike() : base("Chaos Strike", 2, Civilization.Fire)
        {
            // Choose 1 of your opponent's untapped creatures in the battle zone. Your creatures can attack it this turn as though it were tapped.
            Abilities.Add(new SpellAbility(new OneShotEffects.CreateContinuousEffectChoiceEffect(new CardFilters.OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true, new CanBeAttackedAsThoughTappedEffect(null, new DuelMastersModels.Durations.UntilTheEndOfTheTurn()))));
        }
    }
}

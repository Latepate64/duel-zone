using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class ChaosStrike : Spell
    {
        public ChaosStrike() : base("Chaos Strike", 2, Common.Civilization.Fire)
        {
            // Choose 1 of your opponent's untapped creatures in the battle zone. Your creatures can attack it this turn as though it were tapped.
            Abilities.Add(new SpellAbility(new OneShotEffects.CreateContinuousEffectChoiceEffect(new CardFilters.OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true, new CanBeAttackedAsThoughTappedEffect(null, new Engine.Durations.UntilTheEndOfTheTurn()))));
        }
    }
}

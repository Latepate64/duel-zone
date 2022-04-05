using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class ChaosStrike : Spell
    {
        public ChaosStrike() : base("Chaos Strike", 2, Common.Civilization.Fire)
        {
            AddSpellAbilities(new ChaosStrikeOneShotEffect());
        }
    }

    class ChaosStrikeOneShotEffect : OneShotEffects.CreateContinuousEffectChoiceEffect
    {
        public ChaosStrikeOneShotEffect() : base(new CardFilters.OpponentsBattleZoneChoosableUntappedCreatureFilter(), 1, 1, true, new ChaosStrikeContinousEffect())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ChaosStrikeOneShotEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's untapped creatures in the battle zone. Your creatures can attack it this turn as though it were tapped.";
        }
    }

    class ChaosStrikeContinousEffect : ContinuousEffects.UntilEndOfTurnEffect, ICanBeAttackedAsThoughTappedEffect
    {
        public ChaosStrikeContinousEffect() : base(new Engine.TargetFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ChaosStrikeContinousEffect();
        }

        public override string ToString()
        {
            return "Your opponent's creatures can attack this creature as though this creature was tapped.";
        }
    }
}

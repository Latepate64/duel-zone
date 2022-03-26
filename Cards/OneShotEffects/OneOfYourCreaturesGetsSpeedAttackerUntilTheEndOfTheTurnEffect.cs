using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.OneShotEffects
{
    class OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect : GrantChoiceEffect
    {
        public OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new OneOfYourCreaturesGetsSpeedAttackerUntilTheEndOfTheTurnEffect();
        }

        public override string ToString()
        {
            return "One of your creatures in the battle zone gets \"speed attacker\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(new CardFilters.TargetsFilter(cards)));
        }
    }

    class ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect : AbilityAddingEffect
    {
        public ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
        }

        public ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(ICardFilter filter) : base(filter, new Durations.UntilTheEndOfTheTurn(), new SpeedAttackerAbility())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsSpeedAttackerUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return "This creature gets \"speed attacker\" until the end of the turn.";
        }
    }
}

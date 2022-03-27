using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.OneShotEffects
{
    class OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect : GrantChoiceEffect
    {
        private readonly IAbility _ability;

        public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(IAbility ability) : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
            _ability = ability;
        }

        public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _ability = effect._ability;
        }

        public override IOneShotEffect Copy()
        {
            return new OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"One of your creatures in the battle zone gets \"{_ability.ToString().ToLower()}\" until the end of the turn.";
        }

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(new CardFilters.TargetsFilter(cards), _ability));
        }
    }

    class ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect : AbilityAddingEffect
    {
        private readonly IAbility _ability;

        public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect effect) : base(effect)
        {
            _ability = effect._ability.Copy();
        }

        public ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(ICardFilter filter, IAbility ability) : base(filter, new Durations.UntilTheEndOfTheTurn(), new SpeedAttackerAbility())
        {
            _ability = ability;
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(this);
        }

        public override string ToString()
        {
            return $"This creature gets \"{_ability.ToString().ToLower()}\" until the end of the turn.";
        }
    }
}

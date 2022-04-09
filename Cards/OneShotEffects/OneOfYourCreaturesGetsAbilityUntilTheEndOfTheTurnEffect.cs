using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects
{
    class OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect : CardSelectionEffect
    {
        private readonly IAbility _ability;

        public OneOfYourCreaturesGetsAbilityUntilTheEndOfTheTurnEffect(IAbility ability) : base(1, 1, true)
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
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(_ability, cards));
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller);
        }
    }
}

using Effects.Continuous;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using Engine.Steps;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class AbilityAddingEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public List<IAbility> Abilities { get; }

        protected AbilityAddingEffect(AbilityAddingEffect effect) : base(effect)
        {
            Abilities = [.. effect.Abilities.Select(x => x.Copy())];
        }

        protected AbilityAddingEffect(params IAbility[] abilities) : base()
        {
            Abilities = [.. abilities];
        }

        public void AddAbility(IGame game)
        {
            foreach (var card in GetAffectedCards(game))
            {
                Abilities.ForEach(x => card.AddGrantedAbility(x.Copy()));
            }
        }

        protected string AbilitiesAsText => string.Join(", ", Abilities.Select(x => x.ToString()));

        protected abstract IEnumerable<Card> GetAffectedCards(IGame game);
    }

    abstract class AddAbilitiesUntilEndOfTurnEffect : AbilityAddingEffect, IExpirable
    {
        private readonly Card[] _cards;

        protected AddAbilitiesUntilEndOfTurnEffect(AddAbilitiesUntilEndOfTurnEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        protected AddAbilitiesUntilEndOfTurnEffect(IAbility ability, params Card[] cards) : base([ability])
        {
            _cards = cards;
        }

        protected AddAbilitiesUntilEndOfTurnEffect(IAbility ability1, IAbility ability2, params Card[] cards) : base([ability1, ability2])
        {
            _cards = cards;
        }

        protected AddAbilitiesUntilEndOfTurnEffect(Card card, params IAbility[] abilities) : base(abilities)
        {
            _cards = [card];
        }

        public bool ShouldExpire(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is PhaseBegunEvent phase && phase.Phase.Type == PhaseOrStep.EndOfTurn;
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game)
        {
            return _cards;
        }
    }
}

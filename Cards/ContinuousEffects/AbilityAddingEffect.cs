using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    abstract class AbilityAddingEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public List<IAbility> Abilities { get; }

        protected AbilityAddingEffect(AbilityAddingEffect effect) : base(effect)
        {
            Abilities = effect.Abilities.Select(x => x.Copy()).ToList();
        }

        protected AbilityAddingEffect(params IAbility[] abilities) : base()
        {
            Abilities = abilities.ToList();
        }

        public void AddAbility(IGame game)
        {
            //foreach (var card in game.GetAllCards(Filter, Controller))
            //{
            //    Abilities.ForEach(x => card.AddGrantedAbility(x.Copy()));
            //}
        }

        protected string AbilitiesAsText => string.Join(", ", Abilities.Select(x => x.ToString()));

        protected abstract IEnumerable<ICard> GetAffectedCards(IGame game);
    }

    abstract class AddAbilitiesUntilEndOfTurnEffect : AbilityAddingEffect, IDuration
    {
        private readonly ICard[] _cards;

        protected AddAbilitiesUntilEndOfTurnEffect(AddAbilitiesUntilEndOfTurnEffect effect) : base(effect)
        {
            _cards = effect._cards;
        }

        protected AddAbilitiesUntilEndOfTurnEffect(IAbility ability, params ICard[] cards) : base(new IAbility[] { ability })
        {
            _cards = cards;
        }

        protected AddAbilitiesUntilEndOfTurnEffect(IAbility ability1, IAbility ability2, params ICard[] cards) : base(new IAbility[] { ability1, ability2 })
        {
            _cards = cards;
        }

        protected AddAbilitiesUntilEndOfTurnEffect(ICard card, params IAbility[] abilities) : base(abilities)
        {
            _cards = new ICard[] { card };
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            throw new System.NotImplementedException();
            //return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game)
        {
            return _cards;
        }
    }
}

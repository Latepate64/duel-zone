using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
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

        protected AbilityAddingEffect(ICardFilter filter, params IAbility[] abilities) : base(filter)
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
    }

    abstract class AddAbilitiesUntilEndOfTurnEffect : AbilityAddingEffect, IDuration
    {
        protected AddAbilitiesUntilEndOfTurnEffect(AddAbilitiesUntilEndOfTurnEffect effect) : base(effect)
        {
        }

        protected AddAbilitiesUntilEndOfTurnEffect(ICardFilter filter, params IAbility[] abilities) : base(filter, abilities)
        {
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }
    }
}

using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.ContinuousEffects
{
    public abstract class AbilityAddingEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public List<IAbility> Abilities { get; }

        protected AbilityAddingEffect(AbilityAddingEffect effect) : base(effect)
        {
            Abilities = effect.Abilities.Select(x => x.Copy()).ToList();
        }

        protected AbilityAddingEffect(ICardFilter filter, IDuration duration, params IAbility[] abilities) : base(filter, duration)
        {
            Abilities = abilities.ToList();
        }

        protected AbilityAddingEffect(ICardFilter filter, params IAbility[] abilities) : base(filter, null)
        {
            Abilities = abilities.ToList();
        }

        public void AddAbility(IGame game)
        {
            foreach (var card in game.GetAllCards(Filter, game.GetAbility(SourceAbility).Controller))
            {
                Abilities.ForEach(x => game.AddAbility(card, x.Copy()));
            }
        }

        protected string AbilitiesAsText => string.Join(", ", Abilities.Select(x => x.ToString()));
    }
}

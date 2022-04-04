using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
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

        protected AbilityAddingEffect(ICardFilter filter, IDuration duration, Condition condition, params IAbility[] abilities) : base(filter, duration, condition)
        {
            Abilities = abilities.ToList();
        }

        public void AddAbility(IGame game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetOwner(card))))
            {
                Abilities.ForEach(x => game.AddAbility(card, x.Copy()));
            }
        }

        protected string AbilitiesAsText => string.Join(", ", Abilities.Select(x => x.ToString()));
    }
}

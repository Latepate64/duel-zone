using Engine.Abilities;
using Engine.Durations;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public class AbilityAddingEffect : CharacteristicModifyingEffect, IAbilityAddingEffect
    {
        public List<IAbility> Abilities { get; }

        public AbilityAddingEffect(AbilityAddingEffect effect) : base(effect)
        {
            Abilities = effect.Abilities.Select(x => x.Copy()).ToList();
        }

        public AbilityAddingEffect(ICardFilter filter, IDuration duration, params IAbility[] abilities) : base(filter, duration)
        {
            Abilities = abilities.ToList();
        }

        public override ContinuousEffect Copy()
        {
            return new AbilityAddingEffect(this);
        }

        public override string ToString()
        {
            return $"{ToStringBase()}{Filter} get {Abilities}{GetDurationAsText()}.";
        }

        public void AddAbility(IGame game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetOwner(card))))
            {
                Abilities.ForEach(x => game.AddAbility(card, x.Copy()));
            }
        }
    }
}

using Engine.Abilities;
using Engine.Durations;
using System.Collections.Generic;
using System.Linq;

namespace Engine.ContinuousEffects
{
    public class AbilityGrantingEffect : CharacteristicModifyingEffect
    {
        public List<IAbility> Abilities { get; }

        public AbilityGrantingEffect(AbilityGrantingEffect effect) : base(effect)
        {
            Abilities = effect.Abilities.Select(x => x.Copy()).ToList();
        }

        public AbilityGrantingEffect(ICardFilter filter, IDuration duration, params IAbility[] abilities) : base(filter, duration)
        {
            Abilities = abilities.ToList();
        }

        public override ContinuousEffect Copy()
        {
            return new AbilityGrantingEffect(this);
        }

        public override void Apply(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetOwner(card))))
            {
                Abilities.ForEach(x => game.AddAbility(card, x.Copy()));
            }
        }

        public override string ToString()
        {
            return $"{ToStringBase()}{Filter} get {Abilities}{GetDurationAsText()}.";
        }
    }
}

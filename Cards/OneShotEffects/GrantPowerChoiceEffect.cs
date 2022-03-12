using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Collections.Generic;
using System.Linq;

namespace Cards.OneShotEffects
{
    class GrantPowerChoiceEffect : GrantChoiceEffect
    {
        public int Power { get; }

        public GrantPowerChoiceEffect(GrantPowerChoiceEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public GrantPowerChoiceEffect(int power) : base(new CardFilters.OwnersBattleZoneCreatureFilter(), 1, 1, true)
        {
            Power = power;
        }

        public override OneShotEffect Copy()
        {
            return new GrantPowerChoiceEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} gets +${Power}{Duration}.";
        }

        protected override void Apply(Game game, Ability source, IEnumerable<Card> cards)
        {
            game.AddContinuousEffects(source, new PowerModifyingEffect(Power, new TargetsFilter(cards.Select(x => x.Id).ToArray()), Duration));
        }
    }
}

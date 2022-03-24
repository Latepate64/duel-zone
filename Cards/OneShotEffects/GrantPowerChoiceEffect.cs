﻿using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
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

        public GrantPowerChoiceEffect(int power) : this(power, new OwnersBattleZoneCreatureFilter())
        {
        }

        public GrantPowerChoiceEffect(int power, CardFilter filter) : base(filter, 1, 1, true)
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

        protected override void Apply(IGame game, IAbility source, params ICard[] cards)
        {
            game.AddContinuousEffects(source, new PowerModifyingEffect(Power, new TargetsFilter(cards.Select(x => x.Id).ToArray()), Duration));
        }
    }
}

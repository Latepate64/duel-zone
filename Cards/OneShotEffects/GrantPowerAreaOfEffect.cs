﻿using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.Durations;

namespace Cards.OneShotEffects
{
    class GrantPowerAreaOfEffect : OneShotAreaOfEffect
    {
        public int Power { get; }

        public GrantPowerAreaOfEffect(int power) : base(new OwnersBattleZoneCreatureFilter())
        {
            Power = power;
        }

        public GrantPowerAreaOfEffect(GrantPowerAreaOfEffect effect) : base(effect)
        {
            Power = effect.Power;
        }

        public override void Apply(Game game, Ability source)
        {
            foreach (var creature in GetAffectedCards(game, source))
            {
                game.AddContinuousEffects(source, new Engine.ContinuousEffects.PowerModifyingEffect(Power, new TargetsFilter(creature.Id), new UntilTheEndOfTheTurn()));
            }
        }

        public override OneShotEffect Copy()
        {
            return new GrantPowerAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} get {Power} until the end of the turn.";
        }
    }
}
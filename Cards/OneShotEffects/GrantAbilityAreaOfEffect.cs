﻿using Cards.CardFilters;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Linq;

namespace Cards.OneShotEffects
{
    class GrantAbilityAreaOfEffect : OneShotEffect
    {
        public Ability Ability { get; }

        public GrantAbilityAreaOfEffect(Ability ability) 
        {
            Ability = ability;
        }

        public GrantAbilityAreaOfEffect(GrantAbilityAreaOfEffect effect)
        {
            Ability = effect.Ability.Copy();
        }

        public override void Apply(Game game, Ability source)
        {
            foreach (var creature in game.BattleZone.GetCreatures(source.Owner).Select(x => x.Id))
            {
                game.AddContinuousEffects(source, new AbilityGrantingEffect(new TargetsFilter(creature), new UntilTheEndOfTheTurn(), Ability.Copy()));
            }
        }

        public override OneShotEffect Copy()
        {
            return new GrantAbilityAreaOfEffect(this);
        }

        public override string ToString()
        {
            return $"Each of your creatures in the battle zone gets ${Ability} until the end of the turn.";
        }
    }
}

﻿using Cards.StaticAbilities;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class GalsaurEffect : ContinuousEffect, IAbilityAddingEffect
    {
        public GalsaurEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
        }

        public void AddAbility(IGame game)
        {
            var ability = game.GetAbility(SourceAbility);
            if (!game.BattleZone.GetCreatures(ability.Controller).Any(x => x.Id != ability.Source))
            {
                foreach (var card in game.GetAllCards(Filter, game.GetAbility(SourceAbility).Controller))
                {
                    game.AddAbility(card, new PowerAttackerAbility(4000));
                    game.AddAbility(card, new DoubleBreakerAbility());
                }
            }
        }

        public override IContinuousEffect Copy()
        {
            return new GalsaurEffect();
        }

        public override string ToString()
        {
            return "While you have no other creatures in the battle zone, this creature has \"power attacker +4000\" and \"double breaker.\"";
        }
    }
}

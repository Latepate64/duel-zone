﻿using DuelMastersCards.CardFilters;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class AuraBlastEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            // Each of your creatures in the battle zone gets "power attacker +2000" until the end of the turn. (While attacking, a creature that has "power attacker +2000" gets + 2000 power.)
            game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetsFilter(game.BattleZone.GetCreatures(source.Owner).Select(x => x.Id)), new UntilTheEndOfTheTurn(), new PowerAttackerAbility(2000)));
        }

        public override OneShotEffect Copy()
        {
            return new AuraBlastEffect();
        }
    }
}
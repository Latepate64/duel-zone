﻿using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM03
{
    class SnipStrikerBullraizer : Creature
    {
        public SnipStrikerBullraizer() : base("Snip Striker Bullraizer", 2, 3000, Race.Dragonoid, Civilization.Fire)
        {
            AddStaticAbilities(new SnipStrikerBullraizerEffect());
        }
    }

    class SnipStrikerBullraizerEffect : ContinuousEffect, ICannotAttackEffect
    {
        public SnipStrikerBullraizerEffect() : base()
        {
        }

        public bool CannotAttack(ICard creature)
        {
            return IsSourceOfAbility(creature) && Game.BattleZone.GetCreatures(Applier.Opponent).Count() > Game.BattleZone.GetCreatures(Applier).Count();
        }

        public override IContinuousEffect Copy()
        {
            return new SnipStrikerBullraizerEffect();
        }

        public override string ToString()
        {
            return "This creature can't attack while your opponent has more creatures in the battle zone than you do.";
        }
    }
}

﻿using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Choices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersModels.Steps
{
    public class DirectAttackStep : TurnBasedActionStep
    {
        internal Guid AttackingCreature { get; private set; }

        public DirectAttackStep(Guid attackingCreature)
        {
            AttackingCreature = attackingCreature;
        }

        public override Step GetNextStep(Duel duel)
        {
            return new EndOfAttackStep();
        }

        public DirectAttackStep(DirectAttackStep step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
        }

        public override Choice PerformTurnBasedAction(Duel duel, Decision decision)
        {
            var creature = duel.GetCard(AttackingCreature);
            var owner = duel.GetOwner(creature);
            var opponent = duel.GetOpponent(owner);
            if (opponent.ShieldZone.Cards.Any())
            {
                int breakAmount = 1;
                if (creature.Abilities.OfType<DoubleBreaker>().Any())
                {
                    breakAmount = 2;
                }
                opponent.PutFromShieldZoneToHand(opponent.ShieldZone.Cards.Take(breakAmount), duel, true);
                return null;
            }
            else
            {
                //TODO: Direct attack victory should be checked as a state-based action instead.
                var gameOver = new GameOver(WinReason.DirectAttack, new List<Guid> { owner.Id }, new List<Guid> { opponent.Id });
                duel.GameOverInformation = gameOver;
                duel.State = DuelState.Over;
                return gameOver;
            }
        }

        public override Step Copy()
        {
            return new DirectAttackStep(this);
        }
    }
}

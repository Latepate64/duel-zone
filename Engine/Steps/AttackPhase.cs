﻿using Engine.ContinuousEffects;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Steps
{
    public class AttackPhase : Phase
    {
        public Guid AttackingCreature { get; protected set; }
        public Guid AttackTarget { get; set; }
        public Guid BlockingCreature { get; set; }

        public AttackPhase()
        {
        }

        public AttackPhase(AttackPhase step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
        }

        public override Phase Copy()
        {
            return new AttackPhase(this);
        }

        public override Phase GetNextPhase(Game game)
        {
            return new EndOfTurnPhase();
        }

        internal void RemoveAttackingCreature(Game game)
        {
            if (AttackingCreature != Guid.Empty)
            {
                var attacker = game.GetCard(AttackingCreature);
                attacker.Power -= game.GetContinuousEffects<PowerAttackerEffect>(attacker).Sum(x => x.GetPower(game, game.GetOwner(attacker)));
                AttackingCreature = Guid.Empty;
            }
        }

        internal void SetAttackingCreature(Card attacker, Game game)
        {
            AttackingCreature = attacker.Id;
            attacker.Power += game.GetContinuousEffects<PowerAttackerEffect>(attacker).Sum(x => x.Power);
        }

        internal override void Play(Game game)
        {
            Step step = new AttackDeclarationStep(this);
            while (step != null && game.Players.Any())
            {
                _steps.Add(step);
                (step as ITurnBasedActionable).PerformTurnBasedAction(game);
                Progress(game);
                step = step.GetNextStep(game);
            }
        }

        private readonly Collection<Step> _steps = new Collection<Step>();
    }
}
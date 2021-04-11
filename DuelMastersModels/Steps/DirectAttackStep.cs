﻿using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System;
using System.Linq;

namespace DuelMastersModels.Steps
{
    internal class DirectAttackStep : Step
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal bool DirectAttack { get; private set; }
        private bool _breakingDone;
        //public ReadOnlyCardCollection BrokenShields { get; private set; }

        internal DirectAttackStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature, bool directAttack) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            DirectAttack = directAttack;
        }

        public override IChoice PlayerActionRequired(IDuel duel)
        {
            if (DirectAttack && !_breakingDone)
            {
                _breakingDone = true;
                if (AttackingCreature == null)
                {
                    throw new InvalidOperationException();
                }
                IPlayer opponent = ActivePlayer.Opponent;
                if (opponent.ShieldZone.Cards.Any())
                {
                    //TODO: consider multibreaker
                    throw new NotImplementedException();
                    //return new BreakShields(ActivePlayer, 1, ActivePlayer.Opponent.ShieldZone.Cards, AttackingCreature);
                }
                else
                {
                    // 509.1. If the nonactive player has no shields left, that player loses the game. This is a state-based action.
                    duel.End(ActivePlayer);
                }
            }
            return null;
        }
    }
}

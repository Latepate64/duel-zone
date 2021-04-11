﻿using DuelMastersModels.Cards;
using DuelMastersModels.Choices;
using System;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    internal class BattleStep : Step
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal IBattleZoneCreature AttackedCreature { get; private set; }
        internal IBattleZoneCreature BlockingCreature { get; private set; }

        internal BattleStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature, IBattleZoneCreature attackedCreature, IBattleZoneCreature blockingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            AttackedCreature = attackedCreature;
            BlockingCreature = blockingCreature;
        }

        public override IChoice PlayerActionRequired(IDuel duel)
        {
            if (duel == null)
            {
                throw new ArgumentNullException(nameof(duel));
            }
            if (BlockingCreature != null)
            {
                duel.Battle(AttackingCreature, BlockingCreature);
            }
            else if (AttackedCreature != null)
            {
                duel.Battle(AttackingCreature, AttackedCreature);
            }
            return null;
        }
    }
}

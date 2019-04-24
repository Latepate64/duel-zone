using DuelMastersModels.Cards;
using DuelMastersModels.PlayerActions;
using System;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : Step
    {
        public Creature AttackingCreature { get; private set; }
        public Creature AttackedCreature { get; private set; }
        public Creature BlockingCreature { get; private set; }

        public BattleStep(Player activePlayer, Creature attackingCreature, Creature attackedCreature, Creature blockingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            AttackedCreature = attackedCreature;
            BlockingCreature = blockingCreature;
        }

        public override PlayerAction PlayerActionRequired(Duel duel)
        {
            if (duel == null)
            {
                throw new ArgumentNullException("duel");
            }
            if (AttackingCreature == null)
            {
                throw new InvalidOperationException("There should be an attacking creature.");
            }
            if (BlockingCreature != null)
            {
                Duel.Battle(AttackingCreature, BlockingCreature, ActivePlayer, duel.CurrentTurn.NonActivePlayer);
                
            }
            if (AttackedCreature != null)
            {
                Duel.Battle(AttackingCreature, AttackedCreature, ActivePlayer, duel.CurrentTurn.NonActivePlayer);
            }
            return null;
        }
    }
}

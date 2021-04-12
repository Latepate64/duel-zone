using DuelMastersModels.Cards;

namespace DuelMastersModels.Steps
{
    /// <summary>
    /// 508.1. If the attacking creature was declared to attack another creature or if the attack was redirected to target a creature, that creature and the attacking creature battle.
    /// </summary>
    public class BattleStep : Step
    {
        internal IBattleZoneCreature AttackingCreature { get; private set; }
        internal IBattleZoneCreature AttackedCreature { get; private set; }
        internal IBattleZoneCreature BlockingCreature { get; private set; }

        public BattleStep(IPlayer activePlayer, IBattleZoneCreature attackingCreature, IBattleZoneCreature attackedCreature, IBattleZoneCreature blockingCreature) : base(activePlayer)
        {
            AttackingCreature = attackingCreature;
            AttackedCreature = attackedCreature;
            BlockingCreature = blockingCreature;
        }

        //TODO
        //public override IChoice PlayerActionRequired(IDuel duel)
        //{
        //    if (duel == null)
        //    {
        //        throw new ArgumentNullException(nameof(duel));
        //    }
        //    if (BlockingCreature != null)
        //    {
        //        duel.Battle(AttackingCreature, BlockingCreature);
        //    }
        //    else if (AttackedCreature != null)
        //    {
        //        duel.Battle(AttackingCreature, AttackedCreature);
        //    }
        //    return null;
        //}
    }
}

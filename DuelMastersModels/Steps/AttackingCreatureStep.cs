using System;

namespace DuelMastersModels.Steps
{
    public abstract class AttackingCreatureStep : TurnBasedActionStep
    {
        public Guid AttackingCreature { get; protected set; }

        protected AttackingCreatureStep() : base()
        {
        }

        protected AttackingCreatureStep(AttackingCreatureStep step) : base(step)
        {
            AttackingCreature = step.AttackingCreature;
        }
    }
}

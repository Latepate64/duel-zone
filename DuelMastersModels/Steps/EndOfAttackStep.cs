﻿namespace DuelMastersModels.Steps
{
    public class EndOfAttackStep : Step
    {
        public EndOfAttackStep()
        {
        }

        public override Step GetNextStep(Game game)
        {
            return new AttackDeclarationStep();
        }

        public override Step Copy()
        {
            return new EndOfAttackStep(this);
        }

        public EndOfAttackStep(EndOfAttackStep step) : base(step) { }
    }
}

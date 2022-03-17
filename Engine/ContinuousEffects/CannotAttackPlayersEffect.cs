﻿namespace Engine.ContinuousEffects
{
    public class CannotAttackPlayersEffect : ContinuousEffect
    {
        public CannotAttackPlayersEffect(CardFilter filter) : base(filter)
        {

        }

        public CannotAttackPlayersEffect(CannotAttackPlayersEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new CannotAttackPlayersEffect(this);
        }

        public override string ToString()
        {
            return $"{Filter} can't attack players{GetDurationAsText()}.";
        }
    }
}

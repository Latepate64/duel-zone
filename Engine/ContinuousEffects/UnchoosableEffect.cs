﻿namespace Engine.ContinuousEffects
{
    public class UnchoosableEffect : ContinuousEffect
    {
        public UnchoosableEffect()
        {
        }

        public UnchoosableEffect(UnchoosableEffect effect) : base(effect)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new UnchoosableEffect(this);
        }

        public override string ToString()
        {
            return $"Your opponent can't choose {Filter}{GetDurationAsText()}.";
        }
    }
}

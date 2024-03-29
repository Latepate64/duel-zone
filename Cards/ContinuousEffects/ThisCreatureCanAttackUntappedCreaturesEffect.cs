﻿using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCanAttackUntappedCreaturesEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect
    {
        public ThisCreatureCanAttackUntappedCreaturesEffect(ThisCreatureCanAttackUntappedCreaturesEffect effect) : base(effect)
        {
        }

        public ThisCreatureCanAttackUntappedCreaturesEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCanAttackUntappedCreaturesEffect(this);
        }

        public override string ToString()
        {
            return "This creature can attack untapped creatures.";
        }

        public bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack, IGame game)
        {
            return IsSourceOfAbility(attacker);
        }
    }
}
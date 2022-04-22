﻿using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCanAttackUntappedCivilizationCreaturesEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect
    {
        private readonly Civilization _civilization;

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(ThisCreatureCanAttackUntappedCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization civilization) : base()
        {
            _civilization = civilization;
        }

        public bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack, IGame game)
        {
            return IsSourceOfAbility(attacker) && targetOfAttack.HasCivilization(_civilization);
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can attack untapped {_civilization.ToString().ToLower()} creatures.";
        }
    }
}
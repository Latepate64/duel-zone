using Common;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect : ContinuousEffect, ICannotBeAttackedEffect
    {
        private readonly Civilization[] _civilizations;

        public ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilizations = effect._civilizations;
        }

        public ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(params Civilization[] civilizations) : base(new Engine.TargetFilter())
        {
            _civilizations = civilizations;
        }

        public bool Applies(Engine.ICard attacker)
        {
            return attacker.Civilizations.Intersect(_civilizations).Any();
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can't be attacked by {string.Join(" or ", _civilizations.Select(x => x.ToString().ToLower()))} creatures.";
        }
    }
}
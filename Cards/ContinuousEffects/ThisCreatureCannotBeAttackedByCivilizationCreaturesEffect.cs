using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect : ContinuousEffect, ICannotBeAttackedEffect, IMultiCivilizationable
    {
        public ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect effect) : base(effect)
        {
            Civilizations = effect.Civilizations;
        }

        public ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(params Civilization[] civilizations) : base()
        {
            Civilizations = civilizations;
        }

        public Civilization[] Civilizations { get; }

        public bool Applies(ICard attacker, ICard targetOfAttack)
        {
            return IsSourceOfAbility(targetOfAttack) && attacker.Civilizations.Intersect(Civilizations).Any();
        }

        public override IContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeAttackedByCivilizationCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can't be attacked by {string.Join(" or ", Civilizations.Select(x => x.ToString().ToLower()))} creatures.";
        }
    }
}
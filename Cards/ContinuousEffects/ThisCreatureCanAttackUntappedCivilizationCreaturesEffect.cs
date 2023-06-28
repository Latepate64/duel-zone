using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCanAttackUntappedCivilizationCreaturesEffect : ContinuousEffect, ICanAttackUntappedCreaturesEffect, ICivilizationable
    {
        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(ThisCreatureCanAttackUntappedCivilizationCreaturesEffect effect) : base(effect)
        {
            Civilization = effect.Civilization;
        }

        public ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(Civilization civilization) : base()
        {
            Civilization = civilization;
        }

        public Civilization Civilization { get; }

        public bool CanAttackUntappedCreature(ICard attacker, ICard targetOfAttack)
        {
            return IsSourceOfAbility(attacker) && targetOfAttack.HasCivilization(Civilization);
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCanAttackUntappedCivilizationCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can attack untapped {Civilization.ToString().ToLower()} creatures.";
        }
    }
}
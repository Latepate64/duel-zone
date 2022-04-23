using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect : ContinuousEffect, IUnblockableEffect, ICivilizationable
    {
        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect effect) : base(effect)
        {
            Civilization = effect.Civilization;
        }

        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Civilization civilization) : base()
        {
            Civilization = civilization;
        }

        public Civilization Civilization { get; }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return IsSourceOfAbility(attacker) && blocker.HasCivilization(Civilization);
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can't be blocked by {Civilization.ToString().ToLower()} creatures.";
        }
    }
}
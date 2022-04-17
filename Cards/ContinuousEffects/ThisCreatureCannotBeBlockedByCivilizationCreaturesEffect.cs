using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect : ContinuousEffect, IUnblockableEffect
    {
        private readonly Civilization _civilization;

        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Civilization civilization) : base()
        {
            _civilization = civilization;
        }

        public bool CannotBeBlocked(ICard attacker, ICard blocker, IAttackable targetOfAttack, IGame game)
        {
            return IsSourceOfAbility(attacker, game) && blocker.HasCivilization(_civilization);
        }

        public override ContinuousEffect Copy()
        {
            return new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(this);
        }

        public override string ToString()
        {
            return $"This creature can't be blocked by {_civilization.ToString().ToLower()} creatures.";
        }
    }
}
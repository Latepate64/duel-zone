using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class ThisCreatureCannotBeBlockedByCivilizationCreaturesAbility : Engine.Abilities.StaticAbility
    {
        public ThisCreatureCannotBeBlockedByCivilizationCreaturesAbility(Civilization civilization) : base(new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(civilization))
        {
        }
    }

    class ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect : UnblockableEffect
    {
        private readonly Civilization _civilization;

        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Civilization civilization) : base(new TargetFilter(), new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(civilization))
        {
            _civilization = civilization;
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

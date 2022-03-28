using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect : UnblockableEffect
    {
        private readonly Civilization _civilization;

        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Civilization civilization) : base(new Engine.TargetFilter(), new Durations.Indefinite(), new CardFilters.OpponentsBattleZoneCivilizationCreatureFilter(civilization))
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
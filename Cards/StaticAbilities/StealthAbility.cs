using Common;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class StealthAbility : Engine.Abilities.StaticAbility
    {
        public StealthAbility(Civilization civilization) : base(new StealthEffect(civilization))
        {
        }
    }

    class StealthEffect : UnblockableEffect
    {
        private readonly Civilization _civilization;

        public StealthEffect(Civilization civilization) : base(new TargetFilter(), new Durations.Indefinite(), new CardFilters.BattleZoneCreatureFilter(), new Conditions.FilterAnyCondition(new CardFilters.OpponentsManaZoneCivilizationCardFilter(civilization)))
        {
            _civilization = civilization;
        }

        public StealthEffect(StealthEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public override IContinuousEffect Copy()
        {
            return new StealthEffect(this);
        }

        public override string ToString()
        {
            return $"{_civilization} stealth";
        }
    }
}
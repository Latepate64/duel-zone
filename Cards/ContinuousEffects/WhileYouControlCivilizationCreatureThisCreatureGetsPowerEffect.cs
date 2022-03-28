using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect : PowerModifyingEffect
    {
        private readonly Civilization _civilization;

        public WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(Civilization civilization, int power) : base(power, new Durations.Indefinite(), new Conditions.FilterAnyCondition(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(civilization)))
        {
            _civilization = civilization;
        }

        public WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public override ContinuousEffect Copy()
        {
            return new WhileYouControlCivilizationCreatureThisCreatureGetsPowerEffect(this);
        }

        public override string ToString()
        {
            return $"While you have a {_civilization} creature in the battle zone, this creature gets +{_power} power.";
        }
    }
}
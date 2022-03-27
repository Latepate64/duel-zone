using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect : PowerModifyingEffect
    {
        private readonly Civilization _civilization;

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Civilization civilization, int power) : base(power, new Durations.Indefinite(), new Conditions.AllOfCivilizationCondition(civilization))
        {
            _civilization = civilization;
        }

        public override IContinuousEffect Copy()
        {
            return new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(this);
        }

        public override string ToString()
        {
            return $"While all the cards in your mana zone are {_civilization.ToString().ToLower()} cards, this creature gets +{_power} power.";
        }
    }
}
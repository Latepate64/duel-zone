using Common;

namespace Cards.StaticAbilities
{
    class WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility : Engine.Abilities.StaticAbility
    {
        private readonly Civilization _civilization;
        private readonly int _power;

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization civilization, int power) : base(new Engine.ContinuousEffects.PowerModifyingEffect(power, new Conditions.AllOfCivilizationCondition(civilization)))
        {
            _civilization = civilization;
            _power = power;
        }

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility ability) : base(ability)
        {
            _civilization = ability._civilization;
            _power = ability._power;
        }

        public override string ToString()
        {
            return $"While all the cards in your mana zone are {_civilization} cards, this creature gets +{_power} power.";
        }
    }
}

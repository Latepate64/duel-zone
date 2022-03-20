using Common;
using Engine.ContinuousEffects;

namespace Cards.StaticAbilities
{
    class WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility : Engine.Abilities.StaticAbility
    {
        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization civilization, int power) : base(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(civilization, power))
        {
        }
    }

    class WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect : PowerModifyingEffect
    {
        private readonly Civilization _civilization;

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Civilization civilization, int power) : base(power, new Conditions.AllOfCivilizationCondition(civilization))
        {
            _civilization = civilization;
        }

        public override ContinuousEffect Copy()
        {
            return new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(this);
        }

        public override string ToString()
        {
            return $"While all the cards in your mana zone are {_civilization} cards, this creature gets +{_power} power.";
        }
    }
}

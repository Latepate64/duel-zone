using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly Civilization _civilization;
        private readonly int _power;

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
            _power = effect._power;
        }

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Civilization civilization, int power) : base()
        {
            _civilization = civilization;
            _power = power;
        }

        public override IContinuousEffect Copy()
        {
            return new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (Source.GetController(game).ManaZone.Cards.All(x => x.HasCivilization(_civilization)))
            {
                GetSourceCard(game).Power += _power;
            }
        }

        public override string ToString()
        {
            return $"While all the cards in your mana zone are {_civilization.ToString().ToLower()} cards, this creature gets +{_power} power.";
        }
    }
}
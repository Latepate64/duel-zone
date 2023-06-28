using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable, ICivilizationable
    {
        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect effect) : base(effect)
        {
            Civilization = effect.Civilization;
            Power = effect.Power;
        }

        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(int power, Civilization civilization) : base()
        {
            Civilization = civilization;
            Power = power;
        }

        public int Power { get; }
        public Civilization Civilization { get; }

        public override IContinuousEffect Copy()
        {
            return new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (Applier.ManaZone.Cards.All(x => x.HasCivilization(Civilization)))
            {
                Source.Power += Power;
            }
        }

        public override string ToString()
        {
            return $"While all the cards in your mana zone are {Civilization.ToString().ToLower()} cards, this creature gets +{Power} power.";
        }
    }
}
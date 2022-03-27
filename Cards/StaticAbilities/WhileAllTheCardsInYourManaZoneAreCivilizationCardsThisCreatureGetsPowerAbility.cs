using Common;

namespace Cards.StaticAbilities
{
    class WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility : Engine.Abilities.StaticAbility
    {
        public WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization civilization, int power) : base(new ContinuousEffects.WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(civilization, power))
        {
        }
    }
}

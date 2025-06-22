using ContinuousEffects;

namespace Cards.DM03
{
    sealed class Mudman : Engine.Creature
    {
        public Mudman() : base("Mudman", 4, 2000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(2000, Interfaces.Civilization.Darkness));
        }
    }
}

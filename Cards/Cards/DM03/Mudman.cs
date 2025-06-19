using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class Mudman : Engine.Creature
    {
        public Mudman() : base("Mudman", 4, 2000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(2000, Engine.Civilization.Darkness));
        }
    }
}

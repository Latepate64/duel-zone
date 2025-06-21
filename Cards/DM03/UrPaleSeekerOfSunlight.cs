using ContinuousEffects;

namespace Cards.DM03
{
    class UrPaleSeekerOfSunlight : Engine.Creature
    {
        public UrPaleSeekerOfSunlight() : base("Ur Pale, Seeker of Sunlight", 4, 2500, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(2000, Interfaces.Civilization.Light));
        }
    }
}

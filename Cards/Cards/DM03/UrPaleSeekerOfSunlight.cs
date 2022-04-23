using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class UrPaleSeekerOfSunlight : Creature
    {
        public UrPaleSeekerOfSunlight() : base("Ur Pale, Seeker of Sunlight", 4, 2500, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(2000, Engine.Civilization.Light));
        }
    }
}

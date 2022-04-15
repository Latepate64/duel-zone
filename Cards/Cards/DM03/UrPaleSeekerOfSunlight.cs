using Cards.ContinuousEffects;

namespace Cards.Cards.DM03
{
    class UrPaleSeekerOfSunlight : Creature
    {
        public UrPaleSeekerOfSunlight() : base("Ur Pale, Seeker of Sunlight", 4, 2500, Engine.Subtype.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Engine.Civilization.Light, 2000));
        }
    }
}

using Common;

namespace Cards.Cards.DM03
{
    class UrPaleSeekerOfSunlight : Creature
    {
        public UrPaleSeekerOfSunlight() : base("Ur Pale, Seeker of Sunlight", 4, 2500, Subtype.MechaThunder, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerAbility(Civilization.Light, 2000));
        }
    }
}

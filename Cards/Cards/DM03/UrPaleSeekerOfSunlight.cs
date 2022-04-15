using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class UrPaleSeekerOfSunlight : Creature
    {
        public UrPaleSeekerOfSunlight() : base("Ur Pale, Seeker of Sunlight", 4, 2500, Engine.Subtype.MechaThunder, Civilization.Light)
        {
            AddStaticAbilities(new WhileAllTheCardsInYourManaZoneAreCivilizationCardsThisCreatureGetsPowerEffect(Civilization.Light, 2000));
        }
    }
}

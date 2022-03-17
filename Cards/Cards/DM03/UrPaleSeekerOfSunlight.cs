using Common;

namespace Cards.Cards.DM03
{
    class UrPaleSeekerOfSunlight : Creature
    {
        public UrPaleSeekerOfSunlight() : base("Ur Pale, Seeker of Sunlight", 4, 2500, Subtype.MechaThunder, Civilization.Light)
        {
            AddAbilities(new Engine.Abilities.StaticAbility(new Engine.ContinuousEffects.PowerModifyingEffect(2000, new Conditions.AllOfCivilizationCondition(Civilization.Light))));
        }
    }
}

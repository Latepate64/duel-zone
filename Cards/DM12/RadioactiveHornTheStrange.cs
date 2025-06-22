using ContinuousEffects;

namespace Cards.DM12
{
    sealed class RadioactiveHornTheStrange : Engine.Creature
    {
        public RadioactiveHornTheStrange() : base("Radioactive Horn, the Strange", 3, 1000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

using Effects.Continuous;

namespace Cards.Cards.DM12
{
    class RadioactiveHornTheStrange : Engine.Creature
    {
        public RadioactiveHornTheStrange() : base("Radioactive Horn, the Strange", 3, 1000, Engine.Race.HornedBeast, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

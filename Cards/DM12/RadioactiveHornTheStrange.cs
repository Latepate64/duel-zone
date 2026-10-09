using Abilities.Static;

namespace Cards.DM12
{
    sealed class RadioactiveHornTheStrange : Creature
    {
        public RadioactiveHornTheStrange() : base("Radioactive Horn, the Strange", 3, 1000, Interfaces.Race.HornedBeast, Interfaces.Civilization.Nature)
        {
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}

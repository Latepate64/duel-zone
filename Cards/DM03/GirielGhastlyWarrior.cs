using ContinuousEffects;

namespace Cards.DM03
{
    class GirielGhastlyWarrior : Engine.Creature
    {
        public GirielGhastlyWarrior() : base("Giriel, Ghastly Warrior", 8, 11000, Interfaces.Race.DemonCommand, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

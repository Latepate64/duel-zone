using ContinuousEffects;

namespace Cards.DM02
{
    class UltracideWorm : EvolutionCreature
    {
        public UltracideWorm() : base("Ultracide Worm", 6, 11000, Interfaces.Race.ParasiteWorm, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

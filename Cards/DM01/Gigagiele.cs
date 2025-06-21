using ContinuousEffects;

namespace Cards.DM01
{
    class Gigagiele : Engine.Creature
    {
        public Gigagiele() : base("Gigagiele", 5, 3000, Interfaces.Race.Chimera, Interfaces.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}

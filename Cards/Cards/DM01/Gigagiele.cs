using Effects.Continuous;

namespace Cards.Cards.DM01
{
    class Gigagiele : Engine.Creature
    {
        public Gigagiele() : base("Gigagiele", 5, 3000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }
    }
}

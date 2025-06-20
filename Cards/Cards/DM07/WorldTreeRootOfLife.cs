using Cards.ContinuousEffects;
using ContinuousEffects;

namespace Cards.Cards.DM07
{
    class WorldTreeRootOfLife : EvolutionCreature
    {
        public WorldTreeRootOfLife() : base("World Tree, Root of Life", 6, 7000, Engine.Race.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
            AddStaticAbilities(new StealthEffect(Engine.Civilization.Darkness));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}

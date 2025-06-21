using OneShotEffects;
using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM02
{
    class SpiralGrass : Engine.Creature
    {
        public SpiralGrass() : base("Spiral Grass", 4, 2500, Interfaces.Race.StarlightTree, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new UntapItAfterItBattlesEffect()));
        }
    }
}
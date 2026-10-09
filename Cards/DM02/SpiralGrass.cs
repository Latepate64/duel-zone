using Abilities.Static;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02
{
    sealed class SpiralGrass : Creature
    {
        public SpiralGrass() : base("Spiral Grass", 4, 2500, Interfaces.Race.StarlightTree, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new UntapItAfterItBattlesEffect()));
        }
    }
}
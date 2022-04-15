using Cards.OneShotEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM02
{
    class SpiralGrass : Creature
    {
        public SpiralGrass() : base("Spiral Grass", 4, 2500, Engine.Subtype.StarlightTree, Engine.Civilization.Light)
        {
            AddBlockerAbility();
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new UntapItAfterItBattlesEffect()));
        }
    }
}
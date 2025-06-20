using Cards.OneShotEffects;
using Abilities.Triggered;
using ContinuousEffects;

namespace Cards.Cards.DM02
{
    class SpiralGrass : Engine.Creature
    {
        public SpiralGrass() : base("Spiral Grass", 4, 2500, Engine.Race.StarlightTree, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new WheneverThisCreatureBlocksAbility(new UntapItAfterItBattlesEffect()));
        }
    }
}
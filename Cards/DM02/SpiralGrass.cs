using Abilities.Static;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM02;

sealed class SpiralGrass : Creature
{
    public SpiralGrass() : base("Spiral Grass", 4, 2500, Race.StarlightTree, Civilization.Light)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(
            new WheneverThisCreatureBlocksAbility(
                new AfterBattleEffect(
                    new AfterBattleDelayedTriggeredAbilityFactory(),
                    new UntapThisCreatureEffect()
                )));
    }
}
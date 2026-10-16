using Abilities.Static;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM05;

sealed class LaByleSeekerOfTheWinds : Creature
{
    public LaByleSeekerOfTheWinds() : base("La Byle, Seeker of the Winds", 7,
        5000, Race.MechaThunder, Civilization.Light)
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
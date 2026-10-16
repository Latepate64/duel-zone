using Abilities.Static;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12;

sealed class NecrodragonJagraveen : Creature
{
    public NecrodragonJagraveen() : base("Necrodragon Jagraveen", 6, 6000,
        Race.ZombieDragon, Civilization.Darkness)
    {
        AddAbilities(new BlockerAbility());
        AddTriggeredAbility(
            new WheneverThisCreatureBlocksAbility(
                new DestroyAfterBattleEffect(
                    new AfterBattleDelayedTriggeredAbilityFactory()
                )));
        AddAbilities(new DoubleBreakerAbility());
    }
}
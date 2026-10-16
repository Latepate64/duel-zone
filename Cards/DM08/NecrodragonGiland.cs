using Abilities.Static;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class NecrodragonGiland : Creature
{
    public NecrodragonGiland() : base("Necrodragon Giland", 4, 6000,
        Race.ZombieDragon, Civilization.Darkness)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(
            new WhenThisCreatureBattlesAbility(
                new AfterBattleEffect(
                    new AfterBattleDelayedTriggeredAbilityFactory(),
                    new DestroyThisCreatureEffect()
                )));
    }
}
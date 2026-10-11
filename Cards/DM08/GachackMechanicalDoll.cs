using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class GachackMechanicalDoll : TurboRushCreature
{
    public GachackMechanicalDoll() : base("Gachack, Mechanical Doll", 3, 2000,
        Race.DeathPuppet, Civilization.Darkness)
    {
        AddTurboRushAbility(
            new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.AllCreatures
                )));
    }
}
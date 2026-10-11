using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM09;

sealed class TrixoWickedDoll : Creature
{
    public TrixoWickedDoll() : base("Trixo, Wicked Doll", 4, 2000,
        Race.DeathPuppet, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureIsAttackingYourOpponentAndIsNotBlockedAbility(
                new DestroyEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: false,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OwnCreatures
                )));
    }
}
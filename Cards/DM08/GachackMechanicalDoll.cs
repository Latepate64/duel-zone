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
                new ChooseAndDestroyCreaturesEffect(
                    1, 1, new CreatureFilter())));
    }
}
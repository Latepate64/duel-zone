using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class BradSuperKickinDynamo : SilentSkillCreature
{
    public BradSuperKickinDynamo() : base("Brad, Super Kickin' Dynamo", 3, 2000,
        Race.Human, Civilization.Fire)
    {
        AddSilentSkillAbility(
            new DestroyEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new BlockerFilter(),
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class Gigamente : SilentSkillCreature
{
    public Gigamente() : base("Gigamente", 4, 3000, Race.Chimera,
        Civilization.Darkness)
    {
        AddSilentSkillAbility(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.Graveyard,
                destination: ZoneType.Hand,
                selectionRange: SelectionRange.OwnCards
        ));
    }
}
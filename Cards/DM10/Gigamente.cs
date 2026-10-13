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
            new SalvageEffect(
                minimum: 1,
                maximum: 1,
                filter: new CreatureFilter(),
                excludeSource: false,
                selectionRange: SelectionRange.OwnCreatures
        ));
    }
}
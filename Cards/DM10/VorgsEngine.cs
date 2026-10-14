using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class VorgsEngine : SilentSkillCreature
{
    public VorgsEngine() : base("Vorg's Engine", 2, 2000, Race.Xenoparts,
        Civilization.Fire)
    {
        AddSilentSkillAbility(
            new CardMovingAreaOfEffect(
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                filter: new MaxPowerFilter(2000),
                selectionRange: SelectionRange.AllCards,
                excludeSource: false));
    }
}
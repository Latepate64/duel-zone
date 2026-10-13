using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

sealed class SoderlightTheColdBlade : SilentSkillCreature
{
    public SoderlightTheColdBlade() : base("Soderlight, the Cold Blade", 4,
        4000, Race.SpiritQuartz, Civilization.Water, Civilization.Darkness)
    {
        AddSilentSkillAbility(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: false,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.Graveyard,
                selectionRange: SelectionRange.OwnCreatures
            ));
    }
}
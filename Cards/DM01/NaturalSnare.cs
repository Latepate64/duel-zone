using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM01;

public sealed class NaturalSnare : Spell
{
    public NaturalSnare() : base("Natural Snare", 6, Civilization.Nature)
    {
        AddShieldTrigger();
        AddSpellAbilities(
            new CardMovingChoiceEffect(
                minimum: 1,
                maximum: 1,
                controllerChooses: true,
                filter: new CreatureFilter(),
                source: ZoneType.BattleZone,
                destination: ZoneType.ManaZone,
                selectionRange: SelectionRange.OpponentsCreatures
            ));
    }
}

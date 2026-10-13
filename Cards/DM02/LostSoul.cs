using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM02;

sealed class LostSoul : Spell
{
    public LostSoul() : base("Lost Soul", 7, Civilization.Darkness)
    {
        AddSpellAbilities(
            new CardMovingAreaOfEffect(
                source: ZoneType.Hand,
                destination: ZoneType.Graveyard,
                filter: new AnyCardFilter(),
                selectionRange: SelectionRange.OpponentsCards,
                excludeSource: false
        ));
    }
}
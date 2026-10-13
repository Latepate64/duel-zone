using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM06;

public sealed class SchukaDukeOfAmnesia : Creature
{
    public SchukaDukeOfAmnesia() : base("Schuka, Duke of Amnesia", 6, 5000,
        Race.DarkLord, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WhenThisCreatureIsDestroyedAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.Hand,
                    destination: ZoneType.Graveyard,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.AllCards,
                    excludeSource: false
        )));
    }
}

using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM08;

sealed class Gigaclaws : TurboRushCreature
{
    public Gigaclaws() : base("Gigaclaws", 5, 2000, Race.Chimera, Civilization.Darkness)
    {
        AddTurboRushAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.Hand,
                    destination: ZoneType.Graveyard,
                    filter: new AnyCardFilter(),
                    selectionRange: SelectionRange.OpponentsCards,
                    excludeSource: false
        )));
    }
}
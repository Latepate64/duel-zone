using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using StaticAbilities;
using CardFilters;

namespace Cards.DM03;

public sealed class EarthstompGiant : Creature
{
    public EarthstompGiant() : base("Earthstomp Giant", 5, 8000, Race.Giant,
        Civilization.Nature)
    {
        AddAbilities(new DoubleBreakerAbility());
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingAreaOfEffect(
                    source: ZoneType.ManaZone,
                    destination: ZoneType.Hand,
                    filter: new CreatureFilter(),
                    selectionRange: SelectionRange.OwnCards
        )));
    }
}

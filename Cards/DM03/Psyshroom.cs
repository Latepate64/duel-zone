using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class Psyshroom : Creature
{
    public Psyshroom() : base("Psyshroom", 4, 2000, Race.BalloonMushroom,
        Civilization.Nature)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CivilizationCardFilter(Civilization.Nature),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.ManaZone
        )));
    }
}

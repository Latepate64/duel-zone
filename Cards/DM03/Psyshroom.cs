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
                new FromGraveyardIntoManaZoneEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CivilizationCardFilter(Civilization.Nature)
        )));
    }
}

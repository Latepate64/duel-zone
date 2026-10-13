using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class RaVuSeekerOfLightning : Creature
{
    public RaVuSeekerOfLightning() : base("Ra Vu, Seeker of Lightning", 6, 4000,
        Race.MechaThunder, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new MultiFilter(
                        new CivilizationCardFilter(Civilization.Light),
                        new SpellFilter()
                    ),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCards
        )));
    }
}

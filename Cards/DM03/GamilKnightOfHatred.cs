using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using CardFilters;

namespace Cards.DM03;

public sealed class GamilKnightOfHatred : Creature
{
    public GamilKnightOfHatred() : base("Gamil, Knight of Hatred", 6, 4000,
        Race.DemonCommand, Civilization.Darkness)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new CardMovingChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Darkness),
                    source: ZoneType.Graveyard,
                    destination: ZoneType.Hand,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}

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
                new SalvageEffect(
                    minimum: 0,
                    maximum: 1,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Darkness),
                    excludeSource: false,
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}

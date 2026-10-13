using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

public sealed class GrimSoulShadowOfReversal : Creature
{
    public GrimSoulShadowOfReversal() : base("Grim Soul, Shadow of Reversal", 5,
        3000, Race.Ghost, Civilization.Darkness)
    {
        AddAbilities(
            new TapAbility(
                new CardMovingChoiceEffect(
                    minimum: 1,
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

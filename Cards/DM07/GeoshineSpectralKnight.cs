using CardFilters;
using Interfaces;
using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM07;

sealed class GeoshineSpectralKnight : Creature
{
    public GeoshineSpectralKnight() : base("Geoshine, Spectral Knight", 5, 4000,
        Race.RainbowPhantom, Civilization.Light)
    {
        AddTriggeredAbility(
            new WheneverThisCreatureAttacksAbility(
                new TapChoiceEffect(
                    minimum: 0,
                    maximum: 1,
                    ownerChooses: true,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Darkness, Civilization.Fire),
                    selectionRange: SelectionRange.AllCreatures
                )));
    }
}
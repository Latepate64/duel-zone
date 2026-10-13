using Abilities;
using CardFilters;
using Interfaces;
using OneShotEffects;

namespace Cards.DM06;

sealed class CosmogoldSpectralKnight : Creature
{
    public CosmogoldSpectralKnight() : base("Cosmogold, Spectral Knight", 4,
        3000, Race.RainbowPhantom, Civilization.Light)
    {
        AddAbilities(
            new TapAbility(
                new ManaRecoveryEffect(
                    minimum: 1,
                    maximum: 1,
                    controllerChooses: true,
                    filter: new SpellFilter(),
                    selectionRange: SelectionRange.OwnCreatures
        )));
    }
}
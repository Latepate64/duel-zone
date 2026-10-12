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
                new SalvageEffect(
                    minimum: 1,
                    maximum: 1,
                    filter: new CivilizationCreatureFilter(
                        Civilization.Darkness),
                    excludeSource: false
        )));
    }
}

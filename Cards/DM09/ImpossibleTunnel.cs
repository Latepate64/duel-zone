using CardFilters;
using ContinuousEffects.Unblockable;
using Interfaces;
using OneShotEffects;

namespace Cards.DM09;

public sealed class ImpossibleTunnel : Spell
{
    public ImpossibleTunnel(RaceCreatureFilterFactory raceCreatureFilterFactory) : base(
        "Impossible Tunnel", 5, Civilization.Water)
    {
        AddSpellAbilities(
            new AddContinuousEffectWithRaceAndFilterEffect(
                new CreaturesCannotBeBlockedEffectFactory(),
                new UntilEndOfThisTurnDuration(),
                new CreatureFilter(),
                raceCreatureFilterFactory));
    }
}

using ContinuousEffects;
using Interfaces;

namespace Cards.Promo;

public sealed class DynoMantisTheMightspinner : EvolutionCreature
{
    public DynoMantisTheMightspinner() : base(
        "Dyno Mantis, the Mightspinner", 5, 7000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddStaticAbilities(new DynoMantisEffect());
    }
}

using ContinuousEffects;
using Interfaces;

namespace Cards.DM05;

public sealed class HornedMutant : Creature
{
    public HornedMutant() : base("Horned Mutant", 5, 3000, Race.Hedrian, Civilization.Darkness)
    {
        AddStaticAbilities(new EachCivilizationCardCostsMoreEffect(1, Civilization.Nature));
    }
}

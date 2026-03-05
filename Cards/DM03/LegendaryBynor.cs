using ContinuousEffects;
using Interfaces;

namespace Cards.DM03;

public sealed class LegendaryBynor : EvolutionCreature
{
    public LegendaryBynor() : base("Legendary Bynor", 6, 8000, Race.Leviathan, Civilization.Water)
    {
        AddStaticAbilities(new LegendaryBynorEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}

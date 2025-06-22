using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class ChekiculVizierOfEndurance : Creature
{
    public ChekiculVizierOfEndurance() : base(
        "Chekicul, Vizier of Endurance", 5, 1000, Race.Initiate, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddStaticAbilities(new ChekiculEffect());
    }
}

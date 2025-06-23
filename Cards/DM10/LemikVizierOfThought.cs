using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class LemikVizierOfThought : Creature
{
    public LemikVizierOfThought() : base("Lemik, Vizier of Thought", 5, 3000, Race.Initiate, Civilization.Light)
    {
        AddStaticAbilities(new LemikVizierOfThoughtEffect());
    }
}

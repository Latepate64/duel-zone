using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM05;

public sealed class CalgoVizierOfRainclouds : Creature
{
    public CalgoVizierOfRainclouds() : base("Calgo, Vizier of Rainclouds", 3, 2000, Race.Initiate, Civilization.Light)
    {
        AddStaticAbilities(new CalgoVizierOfRaincloudsEffect());
    }
}

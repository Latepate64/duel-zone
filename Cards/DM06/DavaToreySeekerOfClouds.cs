using ContinuousEffects;
using Interfaces;

namespace Cards.DM06;

public sealed class DavaToreySeekerOfClouds : Creature
{
    public DavaToreySeekerOfClouds() : base(
        "Dava Torey, Seeker of Clouds", 6, 5000, Race.MechaThunder, Civilization.Light)
    {
        AddStaticAbilities(new DavaToreyEffect());
    }
}

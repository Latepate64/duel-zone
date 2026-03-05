using ContinuousEffects;
using Interfaces;

namespace Cards.DM12;

public sealed class PincerScarab : Creature
{
    public PincerScarab() : base("Pincer Scarab", 4, 1000, Race.GiantInsect, Civilization.Nature)
    {
        AddStaticAbilities(new PincerScarabEffect(), new PoweredDoubleBreaker());
    }
}

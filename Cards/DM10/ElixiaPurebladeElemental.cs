using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class ElixiaPurebladeElemental : Creature
{
    public ElixiaPurebladeElemental() : base(
        "Elixia, Pureblade Elemental", 6, 1000, Race.AngelCommand, Civilization.Light)
    {
        AddStaticAbilities(new ElixiaEffect(), new PoweredTripleBreaker());
    }
}

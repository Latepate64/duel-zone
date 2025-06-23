using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM06;

public sealed class Kyuroro : Creature
{
    public Kyuroro() : base("Kyuroro", 6, 2000, Race.CyberLord, Civilization.Water)
    {
        AddStaticAbilities(new KyuroroEffect());
    }
}

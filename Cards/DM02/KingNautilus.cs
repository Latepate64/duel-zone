using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM02;

public class KingNautilus : Creature
{
    public KingNautilus() : base("King Nautilus", 8, 6000, Race.Leviathan, Civilization.Water)
    {
        AddStaticAbilities(new KingNautilusEffect());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}

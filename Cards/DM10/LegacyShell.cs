using ContinuousEffects;
using Interfaces;

namespace Cards.DM10;

public sealed class LegacyShell : Creature
{
    public LegacyShell() : base("Legacy Shell", 5, 4000, Race.ColonyBeetle, Civilization.Nature)
    {
        AddStaticAbilities(new LegacyShellEffect());
    }
}

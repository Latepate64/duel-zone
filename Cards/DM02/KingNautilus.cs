using Abilities.Static;
using ContinuousEffects.Unblockable;
using Interfaces;

namespace Cards.DM02;

public sealed class KingNautilus : Creature
{
    public KingNautilus() : base("King Nautilus", 8, 6000, Race.Leviathan, Civilization.Water)
    {
        AddStaticAbilities(new KingNautilusEffect());
        AddAbilities(new DoubleBreakerAbility());
    }
}

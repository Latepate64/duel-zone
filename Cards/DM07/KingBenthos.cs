using ContinuousEffects;
using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM07;

public sealed class KingBenthos : Creature
{
    public KingBenthos() : base("King Benthos", 8, 6000, Race.Leviathan, Civilization.Water)
    {
        AddStaticAbilities(new DoubleBreakerEffect());
        AddAbilities(new TapAbility(new KingBenthosEffect()));
    }
}

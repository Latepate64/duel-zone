using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class TagtappTheRetaliator : Creature
{
    public TagtappTheRetaliator() : base(
        "Tagtapp, the Retaliator", 3, 3000, Race.SpiritQuartz, Civilization.Fire, Civilization.Nature)
    {
        AddStaticAbilities(new TagtappTheRetaliatorEffect(), new PoweredDoubleBreaker());
    }
}

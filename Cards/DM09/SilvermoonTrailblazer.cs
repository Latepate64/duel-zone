using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM09;

public sealed class SilvermoonTrailblazer : Creature
{
    public SilvermoonTrailblazer() : base("Silvermoon Trailblazer", 4, 3000, Race.BeastFolk, Civilization.Nature)
    {
        AddAbilities(new TapAbility(new SilvermoonTrailblazerOneShotEffect()));
    }
}

using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class RagingDashHorn : Creature
{
    public RagingDashHorn() : base("Raging Dash-Horn", 5, 4000, Race.HornedBeast, Civilization.Nature)
    {
        AddStaticAbilities(new RagingDashHornEffect());
    }
}

using ContinuousEffects;
using Interfaces;

namespace Cards.DM03;

public sealed class SnipStrikerBullraizer : Creature
{
    public SnipStrikerBullraizer() : base("Snip Striker Bullraizer", 2, 3000, Race.Dragonoid, Civilization.Fire)
    {
        AddStaticAbilities(new SnipStrikerBullraizerEffect());
    }
}

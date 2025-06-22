using Engine;
using Interfaces;

namespace Cards.DM03;

public class SnipStrikerBullraizer : Creature
{
    public SnipStrikerBullraizer() : base("Snip Striker Bullraizer", 2, 3000, Race.Dragonoid, Civilization.Fire)
    {
        AddStaticAbilities(new SnipStrikerBullraizerEffect());
    }
}

using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class SparkleFlower : Creature
{
    public SparkleFlower() : base("Sparkle Flower", 4, 3000, Race.StarlightTree, Civilization.Light)
    {
        AddStaticAbilities(new SparkleFlowerEffect());
    }
}

using Engine;
using Interfaces;

namespace Cards.DM04;

public sealed class KeeperOfTheSunlitAbyss : Creature
{
    public KeeperOfTheSunlitAbyss() : base("Keeper of the Sunlit Abyss", 4, 1000, Race.CyberVirus, Civilization.Water)
    {
        AddStaticAbilities(new KeeperOfTheSunlitAbyssEffect());
    }
}

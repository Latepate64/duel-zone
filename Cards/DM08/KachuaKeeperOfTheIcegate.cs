using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM08;

public sealed class KachuaKeeperOfTheIcegate : Creature
{
    public KachuaKeeperOfTheIcegate() : base(
        "Kachua, Keeper of the Icegate", 7, 3000, Race.SnowFaerie, Civilization.Nature)
    {
        AddAbilities(new TapAbility(new KachuaEffect()));
    }
}

using Engine;
using Interfaces;

namespace Cards.DM10;

public sealed class UltimateDragon : Creature
{
    public UltimateDragon() : base("Ultimate Dragon", 6, 5000, Race.ArmoredDragon, Civilization.Fire)
    {
        AddStaticAbilities(new UltimateDragonPowerEffect(), new UltimateDragonBreakerEffect());
    }
}

using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM06;

public sealed class AdomisTheOracle : Creature
{
    public AdomisTheOracle() : base("Adomis, the Oracle", 3, 2000, Race.LightBringer, Civilization.Light)
    {
        AddAbilities(new TapAbility(new AdomisTheOracleEffect()));
    }
}

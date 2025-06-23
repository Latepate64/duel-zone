using Interfaces;

namespace Cards.DM11;

public sealed class MerleeTheOracle : WaveStrikerCreature
{
    public MerleeTheOracle() : base("Merlee, the Oracle", 2, 1500, Race.LightBringer, Civilization.Light)
    {
        AddWaveStrikerAbility(new MerleeTheOracleEffect());
    }
}

using Interfaces;

namespace Cards.DM11;

public sealed class LamielDestinyEnforcer : WaveStrikerCreature
{
    public LamielDestinyEnforcer() : base("Lamiel, Destiny Enforcer", 5, 3000, Race.Berserker, Civilization.Light)
    {
        AddWaveStrikerAbility(new LamielAbility());
    }
}

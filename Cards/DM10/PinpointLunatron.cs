using Interfaces;
using OneShotEffects;

namespace Cards.DM10;

public sealed class PinpointLunatron : SilentSkillCreature
{
    public PinpointLunatron() : base("Pinpoint Lunatron", 6, 2000, Race.CyberMoon, Civilization.Water)
    {
        AddSilentSkillAbility(new PinpointLunatronEffect());
    }
}

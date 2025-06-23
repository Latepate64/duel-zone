using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM11;

public sealed class WarpedLunatron : Creature
{
    public WarpedLunatron() : base("Warped Lunatron", 7, 6000, Race.CyberMoon, Civilization.Water)
    {
        AddStaticAbilities(new WarpedLunatronEffect());
        AddTriggeredAbility(new WarpedLunatronAbility());
        AddStaticAbilities(new DoubleBreakerEffect());
    }
}

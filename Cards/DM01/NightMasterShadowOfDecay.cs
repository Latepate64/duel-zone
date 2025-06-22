using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM01;

public sealed class NightMasterShadowOfDecay : Creature
{
    public NightMasterShadowOfDecay() : base(
        "Night Master, Shadow of Decay", 6, 3000, Race.Ghost, Civilization.Darkness)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
    }
}

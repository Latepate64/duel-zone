using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM09;

public sealed class GabzagulWarlordOfPain : Creature
{
    public GabzagulWarlordOfPain() : base("Gabzagul, Warlord of Pain", 6, 5000, Race.DarkLord, Civilization.Darkness)
    {
        AddStaticAbilities(new GabzagulWarlordOfPainEffect());
    }
}

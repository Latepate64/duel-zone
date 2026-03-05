using ContinuousEffects;
using Interfaces;

namespace Cards.DM04;

public sealed class SupportingTulip : Creature
{
    public SupportingTulip() : base("Supporting Tulip", 5, 4000, Race.TreeFolk, Civilization.Nature)
    {
        AddStaticAbilities(new SupportingTulipEffect());
    }
}

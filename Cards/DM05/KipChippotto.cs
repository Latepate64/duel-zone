using ContinuousEffects;
using Interfaces;

namespace Cards.DM05;

public sealed class KipChippotto : Creature
{
    public KipChippotto() : base("Kip Chippotto", 2, 1000, Race.FireBird, Civilization.Fire)
    {
        AddStaticAbilities(new KipChippottoEffect());
    }
}

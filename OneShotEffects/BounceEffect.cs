using Engine;

namespace OneShotEffects;

public abstract class BounceEffect : CardMovingChoiceEffect<Creature>
{
    protected BounceEffect(int minimum, int maximum) : base(minimum, maximum, true, ZoneType.BattleZone, ZoneType.Hand)
    {
    }

    protected BounceEffect(BounceEffect effect) : base(effect)
    {
    }
}

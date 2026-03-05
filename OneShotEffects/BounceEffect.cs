using Interfaces;

namespace OneShotEffects;

public abstract class BounceEffect : CardMovingChoiceEffect<ICreature>
{
    protected BounceEffect(int minimum, int maximum) : base(minimum, maximum, true, ZoneType.BattleZone, ZoneType.Hand)
    {
    }

    protected BounceEffect(BounceEffect effect) : base(effect)
    {
    }
}

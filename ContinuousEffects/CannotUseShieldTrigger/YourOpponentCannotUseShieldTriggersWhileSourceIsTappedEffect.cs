using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotUseShieldTrigger;

public sealed class YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffect
    : ContinuousEffect, ICannotUseShieldTriggerEffect
{
    public YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffect()
    {
    }

    private YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffect(
        YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffect effect) : base(effect)
    {
    }

    public bool CannotUseShieldTrigger(ICard shield, IGame game)
    {
        return Source!.Tapped && shield.OwnerV2.Equals(Applier.Opponent);
    }

    public override IContinuousEffect Copy()
    {
        return new YourOpponentCannotUseShieldTriggersWhileSourceIsTappedEffect(this);
    }
}

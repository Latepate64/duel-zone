using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ShieldRecoveryCanUseShieldTriggerEffect : ShieldRecoveryEffect
{
    public ShieldRecoveryCanUseShieldTriggerEffect() : base(true, 1)
    {
    }

    public ShieldRecoveryCanUseShieldTriggerEffect(ShieldRecoveryEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ShieldRecoveryCanUseShieldTriggerEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your shields and put it into your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ShieldZone.Cards;
    }
}

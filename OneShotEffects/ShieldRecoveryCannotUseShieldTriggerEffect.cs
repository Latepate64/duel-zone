using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public class ShieldRecoveryCannotUseShieldTriggerEffect : ShieldRecoveryEffect
{
    public ShieldRecoveryCannotUseShieldTriggerEffect() : base(false, 1)
    {
    }

    public ShieldRecoveryCannotUseShieldTriggerEffect(ShieldRecoveryEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ShieldRecoveryCannotUseShieldTriggerEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your shields and put it into your hand. You can't use the \"shield trigger\" ability of that shield.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ShieldZone.Cards;
    }
}

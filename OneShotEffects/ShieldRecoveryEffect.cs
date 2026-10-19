using Interfaces;

namespace OneShotEffects;

public sealed class ShieldRecoveryEffect : CardSelectionEffect<ICard>
{
    private readonly bool canUseShieldTrigger;

    public ShieldRecoveryEffect(
        int minimum,
        int maximum,
        bool controllerChooses,
        bool canUseShieldTrigger) : base(
            minimum, maximum, controllerChooses)
    {
        this.canUseShieldTrigger = canUseShieldTrigger;
    }

    private ShieldRecoveryEffect(ShieldRecoveryEffect effect) : base(effect)
    {
        canUseShieldTrigger = effect.canUseShieldTrigger;
    }

    protected override void Apply(
        IGame game, IAbility source, params ICard[] cards)
    {
        game.PutFromShieldZoneToHand(cards, canUseShieldTrigger, Ability);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Controller.ShieldZone.Cards;
    }

    public override IOneShotEffect Copy()
    {
        return new ShieldRecoveryEffect(this);
    }
}

using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public abstract class ShieldRecoveryEffect : CardSelectionEffect<ICard>
{
    public bool CanUseShieldTrigger { get; }

    protected ShieldRecoveryEffect(ShieldRecoveryEffect effect) : base(effect)
    {
    }

    protected ShieldRecoveryEffect(int minimum, int maximum, bool controllerChooses, bool canUseShieldTrigger) : base(
        minimum, maximum, controllerChooses)
    {
        CanUseShieldTrigger = canUseShieldTrigger;
    }

    /// <summary>
    /// Must choose one of own shields.
    /// </summary>
    /// <param name="canUseShieldTrigger"></param>
    protected ShieldRecoveryEffect(bool canUseShieldTrigger, int amonunt) : this(
        amonunt, amonunt, true, canUseShieldTrigger)
    {
    }

    protected override void Apply(IGame game, IAbility source, params ICard[] cards)
    {
        game.PutFromShieldZoneToHand(cards, CanUseShieldTrigger, Ability);
    }
}

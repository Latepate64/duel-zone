using Interfaces;

namespace OneShotEffects;

public sealed class YouMayReturnSpellFromYourManaZoneToYourHandEffect : SelfManaRecoveryEffect
{
    public YouMayReturnSpellFromYourManaZoneToYourHandEffect() : base(0, 1, true)
    {
    }

    public YouMayReturnSpellFromYourManaZoneToYourHandEffect(SelfManaRecoveryEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayReturnSpellFromYourManaZoneToYourHandEffect(this);
    }

    public override string ToString()
    {
        return "You may return a spell from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.Spells;
    }
}

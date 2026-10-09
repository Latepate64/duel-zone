using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotUseCard;

/// <summary>
/// You can cast this spell only if all the cards in your mana zone are fire cards.
/// </summary>
public sealed class BlazeCannonRestrictionEffect : ContinuousEffect,
    ICannotUseCardEffect
{
    public BlazeCannonRestrictionEffect(
        BlazeCannonRestrictionEffect effect) : base(effect)
    {
    }

    public BlazeCannonRestrictionEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new BlazeCannonRestrictionEffect(this);
    }

    public bool Applies(ICard card)
    {
        if (!IsSourceOfAbility(card)) return false;
        if (Applier.ManaZone.AreAllCivilizationCards(
            Civilization.Fire)) return false;
        return true;
    }
}

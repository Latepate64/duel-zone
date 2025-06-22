using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

public sealed class BlazeCannonRestrictionEffect : ContinuousEffect, ICannotUseCardEffect
{
    public BlazeCannonRestrictionEffect(BlazeCannonRestrictionEffect effect) : base(effect)
    {
    }

    public BlazeCannonRestrictionEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new BlazeCannonRestrictionEffect(this);
    }

    public override string ToString()
    {
        return "You can cast this spell only if all the cards in your mana zone are fire cards.";
    }

    public bool Applies(ICard card, IGame game)
    {
        return IsSourceOfAbility(card) && !Ability.Controller.ManaZone.AreAllCivilizationCards(Civilization.Fire);
    }
}

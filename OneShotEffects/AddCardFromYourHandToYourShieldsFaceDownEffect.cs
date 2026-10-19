using Interfaces;

namespace OneShotEffects;

/// <summary>
/// Add a card from your hand to your shields face down.
/// </summary>
public sealed class AddCardFromYourHandToYourShieldsFaceDownEffect
    : CardSelectionEffect<ICard>
{
    public AddCardFromYourHandToYourShieldsFaceDownEffect() : base(1, 1, true)
    {
    }

    public AddCardFromYourHandToYourShieldsFaceDownEffect(
        AddCardFromYourHandToYourShieldsFaceDownEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new AddCardFromYourHandToYourShieldsFaceDownEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(
        IGame game, IAbility source)
    {
        return Controller.Hand.Cards;
    }

    protected override void Apply(
        IGame game, IAbility source, params ICard[] cards)
    {
        game.Move(Ability, ZoneType.Hand, ZoneType.ShieldZone, cards);
    }
}

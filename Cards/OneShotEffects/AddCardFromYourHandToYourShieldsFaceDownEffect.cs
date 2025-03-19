using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.OneShotEffects;

public class AddCardFromYourHandToYourShieldsFaceDownEffect :
    ShieldAdditionEffect
{
    public AddCardFromYourHandToYourShieldsFaceDownEffect() : base(1, 1, true)
    {
    }

    AddCardFromYourHandToYourShieldsFaceDownEffect(ShieldAdditionEffect effect)
        : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new AddCardFromYourHandToYourShieldsFaceDownEffect(this);
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game,
        IAbility source)
    {
        return Controller.Hand.Cards;
    }
}

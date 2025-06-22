using Engine.Abilities;
using Interfaces;

namespace OneShotEffects;

public sealed class ReturnCreatureFromYourGraveyardToYourHandEffect : SalvageCreatureEffect
{
    public ReturnCreatureFromYourGraveyardToYourHandEffect() : base(1, 1)
    {
    }

    public ReturnCreatureFromYourGraveyardToYourHandEffect(SalvageCreatureEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ReturnCreatureFromYourGraveyardToYourHandEffect(this);
    }

    public override string ToString()
    {
        return "Return a creature from your graveyard to your hand.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.Creatures;
    }
}

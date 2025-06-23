using Engine.Abilities;
using Interfaces;
using OneShotEffects;
using System.Collections.Generic;

namespace OneShotEffects;

public sealed class BlissTotemAvatarOfLuckEffect : FromGraveyardIntoManaZoneEffect
{
    public BlissTotemAvatarOfLuckEffect() : base(0, 3, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new BlissTotemAvatarOfLuckEffect();
    }

    public override string ToString()
    {
        return "Put up to 3 cards from your graveyard into your mana zone.";
    }

    protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
    {
        return Controller.Graveyard.Cards;
    }
}

using Engine.Abilities;
using System.Collections.Generic;
using Interfaces;

namespace Cards.DM10;

public sealed class EarthRipperTalonOfRageEffect : OneShotEffects.ManaRecoveryAreaOfEffect
{
    public EarthRipperTalonOfRageEffect() : base()
    {
    }

    public override IOneShotEffect Copy()
    {
        return new EarthRipperTalonOfRageEffect();
    }

    public override string ToString()
    {
        return "Return all tapped cards from your mana zone to your hand.";
    }

    protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
    {
        return Controller.ManaZone.TappedCards;
    }
}

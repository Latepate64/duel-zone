using Engine.Abilities;
using OneShotEffects;

namespace Cards.DM04;

public sealed class SmileAnglerEffect : OpponentManaRecoveryEffect
{
    public SmileAnglerEffect() : base(0, 1, true)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new SmileAnglerEffect();
    }

    public override string ToString()
    {
        return "You may choose a card in your opponent's mana zone and return it to his hand.";
    }
}

using OneShotEffects;
using Engine.Abilities;

namespace Cards.DM03;

public class ShtraEffect : MutualManaRecoveryEffect
{
    public ShtraEffect() : base(1)
    {
    }

    public ShtraEffect(MutualManaRecoveryEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new ShtraEffect(this);
    }

    public override string ToString()
    {
        return "Return a card from your mana zone to your hand. Then your opponent chooses a card in his mana zone and returns it to his hand.";
    }
}

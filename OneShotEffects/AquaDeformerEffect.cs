using Interfaces;

namespace OneShotEffects;

public sealed class AquaDeformerEffect : MutualManaRecoveryEffect
{
    public AquaDeformerEffect() : base(1)
    {
    }

    public AquaDeformerEffect(MutualManaRecoveryEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new AquaDeformerEffect(this);
    }

    public override string ToString()
    {
        return "When you put this creature into the battle zone, return 2 cards from your mana zone to your hand. Then your opponent chooses 2 cards in his mana zone and returns them to his hand.";
    }
}

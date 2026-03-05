using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects;

public sealed class JackViperShadowOfDoomEffect : DestructionReplacementOptionallyToHandEffect
{
    public JackViperShadowOfDoomEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new JackViperShadowOfDoomEffect();
    }

    public override string ToString()
    {
        return "Whenever another of your darkness creatures would be put into your graveyard from the battle zone, you may return it to your hand instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return !IsSourceOfAbility(card) && card.Owner == Controller && card.HasCivilization(Civilization.Darkness);
    }
}

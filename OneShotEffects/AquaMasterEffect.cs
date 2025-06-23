using Interfaces;

namespace OneShotEffects;

public sealed class AquaMasterEffect : OneShotEffect
{
    public AquaMasterEffect()
    {
    }

    public AquaMasterEffect(IOneShotEffect effect) : base(effect)
    {
    }

    public override void Apply(IGame game)
    {
        var shield = Controller.ChooseCard(GetOpponent(game).ShieldZone.Cards, ToString());
        shield?.TurnFaceUp();
    }

    public override IOneShotEffect Copy()
    {
        return new AquaMasterEffect(this);
    }

    public override string ToString()
    {
        return "Choose one of your opponent's shields and turn it face up.";
    }
}
